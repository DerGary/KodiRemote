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

namespace KodiRemote.View.Video {
    public sealed partial class CollectionPage : PageBase {
        public CollectionViewModel ViewModel { get; set; } =  new CollectionViewModel();
        public override ViewModelBase ViewModelBase { get { return ViewModel; } }

        public CollectionPage() {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            var pagetype = (PageType)e.Parameter;
            await ViewModel.Init(pagetype);

            base.OnNavigatedTo(e);
        }

        private void HorizontalGridViewPage_Navigate(ItemViewModel item) {
            if (ViewModel.PageType == PageType.Movies) {
                Frame.Navigate(typeof(MovieDetailsPage), item.Item);
            }
        }
    }
}
