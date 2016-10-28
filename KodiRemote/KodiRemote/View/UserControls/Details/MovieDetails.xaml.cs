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
using KodiRemote.Code.Database.GeneralTables;

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

        public delegate void MovieClickedEventHandler(MovieTableEntry item);
        public event MovieClickedEventHandler MovieClicked;

        public delegate void ActorClickedEventHandler(ActorTableEntry item);
        public event ActorClickedEventHandler ActorClicked;

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(MovieDetails), null);

        public Orientation Orientation {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public MovieDetails() {
            this.InitializeComponent();
        }

        private void MovieSetMovieClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            MovieClicked?.Invoke(viewModel.Item as MovieTableEntry);
        }

        private void ActorGridClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ActorViewModel;
            ActorClicked?.Invoke(viewModel.Item as ActorTableEntry);
        }
    }
}
