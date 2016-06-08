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

namespace KodiRemote.ViewModel {
    public class ActorViewModel : ItemViewModel {
        public int ActorId { get; }
        public string Name { get; set; }
        public string Role { get; set; }


        public ActorViewModel(MovieActorMapper item) : base(item.Actor) {
            this.ActorId = item.ActorId;
            this.Name = item.Actor.Name;
            this.Role = item.Role;
        }
    }

    public class MovieDetailsViewModel : ItemViewModel {
        public MovieDetailsViewModel(object item) : base(item) {
            Movie = item as MovieTableEntry;
            Title = Movie.Label;
        }

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


        public static async Task<MovieDetailsViewModel> Init(MovieTableEntry movieTableEntry) {
            var movie = await Kodi.ActiveInstance.Database.GetMovie(movieTableEntry);
            return new MovieDetailsViewModel(movie);
        }
    }
}
