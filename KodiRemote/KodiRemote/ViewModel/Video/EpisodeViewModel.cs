using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.KPlayer.Params;
using KodiRemote.Code.JSON.Enums;

namespace KodiRemote.ViewModel.Video {
    public class EpisodeViewModel : ItemViewModel {
        public float Rating { get; set; }
        public int Runtime { get; set; }
        public int Episode { get; set; }

        public EpisodeViewModel(EpisodeTableEntry item) : base(item) {
            Rating = item.Rating;
            Runtime = item.Runtime;
            Episode = item.Episode;
            label = item.Title;
        }

    }
}
