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
using KodiRemote.Code.Database.GeneralTables;

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
        

        private void MovieDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                ScrollViewer.ChangeView(App.ScrollViewerHorizontalOffset.Pop(), 0, 1, true);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if(e.NavigationMode == NavigationMode.Back) {
                ViewModel = (MovieDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new MovieDetailsViewModel(e.Parameter as MovieTableEntry);
                await ViewModel.Init();
                PopInAnimation(ScrollViewer, ProgressRing);
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if(e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerHorizontalOffset.Push(ScrollViewer.HorizontalOffset);
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }
        #endregion Navigation
        

        private void MovieClicked(MovieTableEntry item) {
            Frame.Navigate(typeof(MovieDetailsPage), item);
        }

        private void ActorClicked(ActorTableEntry item) {
            Frame.Navigate(typeof(ActorDetailsPage), item);
        }
    }
}
