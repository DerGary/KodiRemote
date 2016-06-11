using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using KodiRemote.ViewModel.Video;

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
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel = await MovieSetDetailsViewModel.Init(e.Parameter as MovieSetTableEntry);
            base.OnNavigatedTo(e);
        }

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ItemViewModel;
            var movie = vm.Item as MovieTableEntry;
            if (movie != null) {
                Frame.Navigate(typeof(MovieDetailsPage), movie);
            }
        }
    }
}
