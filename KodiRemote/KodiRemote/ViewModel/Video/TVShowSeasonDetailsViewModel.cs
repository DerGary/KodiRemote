using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;

namespace KodiRemote.ViewModel.Video {
    public class TVShowSeasonDetailsViewModel : ItemViewModel {
        private TVShowSeasonTableEntry tvshowSeason;
        public TVShowSeasonTableEntry TVShowSeason {
            get {
                return tvshowSeason;
            }
            set {
                tvshowSeason = value;
                RaisePropertyChanged();
            }
        }
        
        public TVShowSeasonDetailsViewModel(TVShowSeasonTableEntry item) : base(item) {
            TVShowSeason = item;
            BackgroundItem = this;
            Title = $"{item.TVShow.Label} - Staffel {item.Season}";
        }

        private RelayCommand play;
        public RelayCommand Play {
            get {
                if(play == null) {
                    play = new RelayCommand(async () => {
                        //await this.Kodi.Player.Open(new Movie() { MovieId = Movie.MovieId }, OptionalRepeatEnum.Null);TODO:
                    });
                }
                return play;
            }
        }
    }
}
