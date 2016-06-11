using KodiRemote.Code.Database.MovieTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;

namespace KodiRemote.ViewModel.Video {
    public class MovieSetDetailsViewModel : ItemViewModel {
        private ObservableCollection<Group<ItemViewModel>> groups;
        public ObservableCollection<Group<ItemViewModel>> Groups {
            get {
                return groups;
            }
            set {
                groups = value;
                RaisePropertyChanged();
            }
        }

        private MovieSetDetailsViewModel(MovieSetTableEntry item) : base(item) {
            BackgroundItem = this;
            Groups = new ObservableCollection<Group<ItemViewModel>>();
            var movies = new ObservableCollection<ItemViewModel>();

            foreach (var movie in item.Movies.Select(x => x.Movie).OrderBy(x => x.Year)) {
                movies.Add(new ItemViewModel(movie));
            }
            if (movies.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "Movies", Items = movies });
            }
        }

        public static async Task<MovieSetDetailsViewModel> Init(MovieSetTableEntry item) {
            var MovieSet = await Kodi.ActiveInstance.Database.GetMovieSet(item);
            return new MovieSetDetailsViewModel(MovieSet);
        }
    }
}
