using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View.Base;
using KodiRemote.View.Video;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class MovieDetails : UserControlBase {
        private MovieTableEntry movie;
        public MovieTableEntry Movie {
            get {
                return movie;
            }
            set {
                movie = value;
                RaisePropertyChanged();
            }
        }

        public MovieDetails() {
            this.InitializeComponent();
        }

        private void MovieSetMovieClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            //Frame.Navigate(typeof(MovieDetailsPage), viewModel.Item);
        }

        private void ActorClicked(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ActorViewModel;
            //Frame.Navigate(typeof(ActorDetailsPage), vm.Item);
        }
    }
}
