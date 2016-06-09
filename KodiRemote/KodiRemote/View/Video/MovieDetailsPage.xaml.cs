using KodiRemote.Code.Database.MovieTables;
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

        public override ViewModelBase ViewModelBase { get { return ViewModel; } }
        public MovieDetailsPage() {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel = await MovieDetailsViewModel.Init(e.Parameter as MovieTableEntry);
            base.OnNavigatedTo(e);
        }

        private void MovieSetMovieClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Frame.Navigate(typeof(MovieDetailsPage), viewModel.Item);
        }

        private void ActorClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ActorViewModel;
            Frame.Navigate(typeof(ActorDetailsPage), viewModel.Item);
        }
    }
}
