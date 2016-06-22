using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class MovieDetailsPage : PageBase {
        private MovieDetailsViewModel viewModel;
        public MovieDetailsViewModel ViewModel {
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

        public MovieDetailsPage() {
            this.InitializeComponent();
            Loaded += MovieDetailsPage_Loaded;
        }

        private NavigationMode navigationMode;

        private void MovieDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (navigationMode == NavigationMode.Back) {
                var horizontalOffset = App.ScrollViewerHorizontalOffset.Pop();
                ScrollViewer.ChangeView(horizontalOffset, 0, 1, true);
                PopInAnimation.Begin();
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if(e.NavigationMode == NavigationMode.Back) {
                ViewModel = (MovieDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new MovieDetailsViewModel(e.Parameter as MovieTableEntry);
                await ViewModel.Init();
                PopInAnimation.Begin();
            }
            navigationMode = e.NavigationMode;
            base.OnNavigatedTo(e);
        }


        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if(e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerHorizontalOffset.Push(ScrollViewer.HorizontalOffset);
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }

        private void MovieSetMovieClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Frame.Navigate(typeof(MovieDetailsPage), viewModel.Item);
        }

        private void ActorClicked(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ActorViewModel;
            Frame.Navigate(typeof(ActorDetailsPage), vm.Item);
        }
    }
}
