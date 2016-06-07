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
            MovieSet = Movie.MovieSets?.FirstOrDefault()?.MovieSet;
            MovieSetMovies = MovieSet?.Movies?.Select(x => new ItemViewModel(x.Movie));
            Actors = Movie.Actors.Select(x => new ActorViewModel(x));
            var genres = Movie.Genres.Select(x => x.Genre.Genre);
            string genre = genres.FirstOrDefault();
            for (int i = 1; i < genres.Count(); i++) {
                genre += ", " + genres.ElementAt(i);
            }
            Genre = genre;
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

        private string genre;
        public string Genre {
            get {
                return genre;
            }
            set {
                genre = value;
                RaisePropertyChanged();
            }
        }


        private MovieSetTableEntry movieSet;
        public MovieSetTableEntry MovieSet {
            get {
                return movieSet;
            }
            set {
                movieSet = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<ItemViewModel> movieSetMovies;
        public IEnumerable<ItemViewModel> MovieSetMovies {
            get {
                return movieSetMovies;
            }
            set {
                movieSetMovies = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<ActorViewModel> actors;
        public IEnumerable<ActorViewModel> Actors {
            get {
                return actors;
            }
            set {
                actors = value;
                RaisePropertyChanged();
            }
        }



        public static async Task<MovieDetailsViewModel> Init(MovieTableEntry movieTableEntry) {
            var movie = await Kodi.ActiveInstance.Database.GetMovie(movieTableEntry);
            return new MovieDetailsViewModel(movie);
        }
    }
}
