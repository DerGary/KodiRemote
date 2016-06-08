using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace KodiRemote.View {
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class HorizontalGridViewPage : PageBase {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(CollectionViewModel), typeof(HorizontalGridViewPage), null);

        public CollectionViewModel ViewModel {
            get { return (CollectionViewModel)GetValue(ViewModelProperty); }
            set {
                SetValue(ViewModelProperty, value);
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }
        public override ViewModelBase ViewModelBase { get { return ViewModel; } }

        public delegate void NavigateEventHandler(ItemViewModel item);
        public event NavigateEventHandler Navigate;


        public HorizontalGridViewPage() {
            this.InitializeComponent();
        }

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Navigate?.Invoke(viewModel);
        }
    }
}
