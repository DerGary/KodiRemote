using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.KPlayer.Params;

namespace KodiRemote.ViewModel.Video {
    public class EpisodeDetailsViewModel : ItemViewModel {
        private EpisodeTableEntry episode;
        public EpisodeTableEntry Episode {
            get {
                return episode;
            }
            set {
                episode = value;
                RaisePropertyChanged();
            }
        }

        private EpisodeDetailsViewModel(EpisodeTableEntry item) : base(item) {
            Episode = item;
            BackgroundItem = this;
            Title = $"{item.TVShowSeason.TVShow.Label} - Staffel {item.TVShowSeason.Season} - Folge {item.Episode} ({item.Title})";
        }

        public static async Task<EpisodeDetailsViewModel> Init(EpisodeTableEntry item) {
            var episode = await Kodi.ActiveInstance.Database.GetEpisode(item);
            return new EpisodeDetailsViewModel(episode);
        }



        private RelayCommand play;
        public RelayCommand Play {
            get {
                if(play == null) {
                    play = new RelayCommand(async () => {
                        await this.Kodi.Player.Open(new Episode() { EpisodeId = Episode.EpisodeId }, OptionalRepeatEnum.Null);
                    });
                }
                return play;
            }
        }
    }
}
