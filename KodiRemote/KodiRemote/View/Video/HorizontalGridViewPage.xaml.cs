using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
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
using KodiRemote.Code.Common;

namespace KodiRemote.View.Video {
    public sealed partial class HorizontalGridViewPage : PageBase {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(CollectionViewModel), typeof(HorizontalGridViewPage), null);

        public CollectionViewModel ViewModel {
            get { return (CollectionViewModel)GetValue(ViewModelProperty); }
            set {
                SetValue(ViewModelProperty, value);
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }
        public override ViewModelBase ViewModelBase => ViewModel;

        public delegate void NavigateEventHandler(ItemViewModel item);
        public event NavigateEventHandler Navigate;

        public HorizontalGridViewPage() {
            this.InitializeComponent();
        }

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Navigate?.Invoke(viewModel);
        }
        public double GetScrollPosition() {
            var scrollviewer = itemGridView.FindVisualChild<ScrollViewer>();
            return scrollviewer.HorizontalOffset;
        }
        public void SetScrollPosition(double position) {
            var scrollviewer = itemGridView.FindVisualChild<ScrollViewer>();
            scrollviewer?.ChangeView(position, 0, 1);
        }

        private void itemGridView_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
