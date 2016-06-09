using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.GeneralTables;
using Windows.UI.Xaml;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace KodiRemote.ViewModel.Video {
    public class MovieDetailsViewModel : ItemViewModel {
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

        public MovieDetailsViewModel(MovieTableEntry item) : base(item) {
            Movie = item;
            Title = Movie.Label;
        }

        public static async Task<MovieDetailsViewModel> Init(MovieTableEntry movieTableEntry) {
            var movie = await Kodi.ActiveInstance.Database.GetMovie(movieTableEntry);
            return new MovieDetailsViewModel(movie);
        }
    }
}
