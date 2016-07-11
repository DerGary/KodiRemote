using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using KodiRemote.ViewModel.Video;
using Windows.UI.Xaml.Media.Animation;

namespace KodiRemote.View.Video {
    public sealed partial class MovieSetDetailsPage : PageBase {
        private MovieSetDetailsViewModel viewModel;
        public MovieSetDetailsViewModel ViewModel {
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

        public MovieSetDetailsPage() {
            this.InitializeComponent();
            Loaded += MovieSetDetailsPage_Loaded;
        }

        private void MovieSetDetailsPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                ScrollViewer.ChangeView(App.ScrollViewerHorizontalOffset.Pop(), 0, 1, true);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (MovieSetDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new MovieSetDetailsViewModel(e.Parameter as MovieSetTableEntry);
                await ViewModel.Init();
                PopInAnimation(ScrollViewer, ProgressRing);
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if (e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerHorizontalOffset.Push(ScrollViewer.HorizontalOffset);
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }
        #endregion Navigation

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ItemViewModel;
            var movie = vm.Item as MovieTableEntry;
            if (movie != null) {
                Frame.Navigate(typeof(MovieDetailsPage), movie);
            }
        }
    }
}
