using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public abstract class EpisodeMapper : TableEntryBase {
        public int EpisodeId { get; set; }
        public EpisodeTableEntry Episode { get; set; }
    }
}
