using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Settings;
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

namespace KodiRemote.View.Settings {
    public sealed partial class AddKodiPage : PageBase {
        private AddKodiViewModel viewModel;
        public AddKodiViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }
        public override ViewModelBase ViewModelBase { get { return ViewModel; } }

        public AddKodiPage() {
            this.InitializeComponent();
        }

        private void DeclineTapped(object sender, TappedRoutedEventArgs e) {
            Frame.GoBack();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ViewModel = new AddKodiViewModel(this.Frame);
        }
    }
}
