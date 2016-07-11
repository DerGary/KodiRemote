using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.KPlayer.Params;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Essentials.Enums;

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
                        if(TVShowSeason?.Episodes == null) {
                            return;
                        }

                        bool first = true;

                        foreach (EpisodeTableEntry episode in TVShowSeason.Episodes) { 
                            if (first) {
                                await Kodi.Player.Open(new Episode { EpisodeId = episode.EpisodeId }, OptionalRepeatEnum.Null);
                                first = false;
                            } else {
                                await Kodi.Playlist.Add(PlaylistTypeEnum.Video.ToInt(), new Code.JSON.KPlaylist.Params.Episode { EpisodeId = episode.EpisodeId });
                            }
                        }
                    });
                }
                return play;
            }
        }
    }
}
