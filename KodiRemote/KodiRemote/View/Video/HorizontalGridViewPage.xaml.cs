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
            return itemGridView.GetHorizontalScrollOffset();
        }

        public void SetScrollPosition(double position) {
            itemGridView.SetHorizontalScrollOffset(position);
        }

        private void ItemRightClick(object sender, RightTappedRoutedEventArgs e) {
            var item = (e.OriginalSource as FrameworkElement).DataContext as ItemViewModel;
            var flyout = new MenuFlyout();
            flyout.Items.Add(new MenuFlyoutItem() { Text = "Play", Command = ViewModel.Play, CommandParameter = item });
            flyout.ShowAt(sender as FrameworkElement, e.GetPosition(sender as FrameworkElement));
        }
    }
}
