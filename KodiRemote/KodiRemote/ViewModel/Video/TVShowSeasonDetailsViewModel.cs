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
        
        private TVShowSeasonDetailsViewModel(TVShowSeasonTableEntry item) : base(item) {
            BackgroundItem = this;
            TVShowSeason = item;
            Title = $"{item.TVShow.Label} - Staffel {item.Season}";
        }

        public static async Task<TVShowSeasonDetailsViewModel> Init(TVShowSeasonTableEntry item) {
            return new TVShowSeasonDetailsViewModel(item);
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
