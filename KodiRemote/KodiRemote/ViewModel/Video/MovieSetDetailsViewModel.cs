using KodiRemote.Code.Database.MovieTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.KPlayer.Params;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.Essentials.Enums;

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


        public MovieSetDetailsViewModel(MovieSetTableEntry item) : base(item) {
            MovieSet = item;
            BackgroundItem = this;
            Groups = new ObservableCollection<Group<ItemViewModel>>();
        }

        public async Task Init() {
            MovieSet = await Kodi.ActiveInstance.Database.GetMovieSet(MovieSet);
            var movies = new ObservableCollection<ItemViewModel>();
            foreach (var movie in MovieSet.Movies.Select(x => x.Movie).OrderBy(x => x.Year)) {
                movies.Add(new ItemViewModel(movie));
            }
            if (movies.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "Movies", Items = movies });
            }
        }

        private RelayCommand play;
        public RelayCommand Play {
            get {
                if(play == null) {
                    play = new RelayCommand(async () => {
                        if(MovieSet?.Movies == null) {
                            return;
                        }

                        bool first = true;

                        foreach (MovieTableEntry movie in MovieSet.Movies.Select(x=> x.Movie)) {
                            if (first) {
                                await Kodi.Player.Open(new Movie { MovieId = movie.MovieId }, OptionalRepeatEnum.Null);
                                first = false;
                            } else {
                                await Kodi.Playlist.Add(PlaylistTypeEnum.Video.ToInt(), new Code.JSON.KPlaylist.Params.Movie { MovieId = movie.MovieId });
                            }
                        }
                    });
                }
                return play;
            }
        }
    }
}
