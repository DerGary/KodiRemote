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
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.KPlayer.Params;

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
            BackgroundItem = this;
        }

        public async Task Init() {
            Movie = await Kodi.ActiveInstance.Database.GetMovie(Movie);
        }

        private RelayCommand play;
        public RelayCommand Play {
            get {
                if(play == null) {
                    play = new RelayCommand(async () => {
                        await Kodi.Player.Open(new Movie() { MovieId = Movie.MovieId }, OptionalRepeatEnum.Null);
                    });
                }
                return play;
            }
        }
    }
}
