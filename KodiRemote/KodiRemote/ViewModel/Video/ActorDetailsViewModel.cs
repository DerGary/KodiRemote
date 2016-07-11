using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;

namespace KodiRemote.ViewModel.Video {
    public class ActorDetailsViewModel : ItemViewModel {
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

        private ActorTableEntry actor;
        public ActorTableEntry Actor {
            get {
                return actor;
            }
            set {
                actor = value;
                RaisePropertyChanged();
            }
        }


        public ActorDetailsViewModel(ActorTableEntry item) : base(item) {
            Actor = item;
            BackgroundItem = null;
            Groups = new ObservableCollection<Group<ItemViewModel>>();
        }

        public async Task Init() {
            Actor = await Kodi.ActiveInstance.Database.GetActor(Actor);
            var tvshows = new ObservableCollection<ItemViewModel>();
            var movies = new ObservableCollection<ItemViewModel>();
            foreach (var tvshowMapper in Actor.TVShows) {
                tvshows.Add(new ItemViewModel(tvshowMapper.TVShow));
            }
            foreach (var movieMapper in Actor.Movies) {
                movies.Add(new ItemViewModel(movieMapper.Movie));
            }
            if (tvshows.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "TVShows", Items = tvshows });
            }
            if (movies.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "Movies", Items = movies });
            }
        }
    }
}
