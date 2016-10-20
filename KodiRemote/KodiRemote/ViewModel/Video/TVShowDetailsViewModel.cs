using KodiRemote.Code.Database.TVShowTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.KPlayer.Params;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.Essentials.Enums;

namespace KodiRemote.ViewModel.Video {
    public class TVShowDetailsViewModel : ItemViewModel {
        private TVShowTableEntry tvshow;
        public TVShowTableEntry TVShow {
            get {
                return tvshow;
            }
            set {
                tvshow = value;
                RaisePropertyChanged();
            }
        }

        public TVShowDetailsViewModel(TVShowTableEntry item) : base(item) {
            TVShow = item;
            BackgroundItem = this;
        }

        public async Task Init() {
            TVShow = await Kodi.Database.GetTVShow(TVShow);
        }

        private RelayCommand play;
        public RelayCommand Play {
            get {
                if (play == null) {
                    play = new RelayCommand(async () => {
                        if (TVShow?.Seasons == null) {
                            return;
                        }
                        bool first = true;

                        foreach (TVShowSeasonTableEntry season in TVShow.Seasons) {
                            if (season.Episodes != null) {
                                foreach (EpisodeTableEntry episode in season.Episodes) {
                                    if (first) {
                                        await Kodi.Player.Open(new Episode { EpisodeId = episode.EpisodeId }, OptionalRepeatEnum.Null);
                                        first = false;
                                    } else {
                                        await Kodi.Playlist.Add(PlaylistTypeEnum.Video.ToInt(), new Code.JSON.KPlaylist.Params.Episode { EpisodeId = episode.EpisodeId });
                                    }
                                }
                            }
                        }
                    });
                }
                return play;
            }
        }
    }
}
