using KodiRemote.Code.Database.TVShowTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;

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
                RaisePropertyChanged(nameof(UnWatchedEpisodes));
            }
        }
        public int UnWatchedEpisodes => TVShow.Episode - TVShow.WatchedEpisodes;

        public TVShowDetailsViewModel(TVShowTableEntry item) : base(item) {
            TVShow = item;
            BackgroundItem = this;
            Title = item.Label;
        }

        public static async Task<TVShowDetailsViewModel> Init(TVShowTableEntry item) {
            var movie = await Kodi.ActiveInstance.Database.GetTVShow(item);
            return new TVShowDetailsViewModel(movie);
        }
    }
}
