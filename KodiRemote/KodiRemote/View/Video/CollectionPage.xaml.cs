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
        private CollectionViewModel viewModel = new CollectionViewModel();
        public CollectionViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }
        
        public override ViewModelBase ViewModelBase => ViewModel; 

        public CollectionPage() {
            this.InitializeComponent();
            HorizontalGridViewPage.Loaded += HorizontalGridViewPage_Loaded;
            PopOutCompleted += CollectionPage_PopOutCompleted;
        }



        private void HorizontalGridViewPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                HorizontalGridViewPage.SetScrollPosition(App.ScrollViewerHorizontalOffset.Pop());
                PopInAnimation(HorizontalGridViewPage, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (CollectionViewModel)App.ViewModels.Pop();
            } else {
                await ViewModel.Init((PageType)e.Parameter);
                PopInAnimation(HorizontalGridViewPage, ProgressRing);
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if(e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerHorizontalOffset.Push(HorizontalGridViewPage.GetScrollPosition());
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }
        #endregion Navigation

        ItemViewModel item;

        private void HorizontalGridViewPage_Navigate(ItemViewModel item) {
            PopOutAnimation(HorizontalGridViewPage);
            this.item = item;
        }

        private void CollectionPage_PopOutCompleted(object sender, object e) {
            if (ViewModel.PageType == PageType.Movies) {
                Frame.Navigate(typeof(MovieDetailsPage), item.Item);
            } else if (ViewModel.PageType == PageType.MovieSets) {
                Frame.Navigate(typeof(MovieSetDetailsPage), item.Item);
            } else if (ViewModel.PageType == PageType.TVShows) {
                Frame.Navigate(typeof(TVShowDetailsPage), item.Item);
            }
        }
    }
}
