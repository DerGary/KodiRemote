using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeSubtitleStreamMapper : EpisodeMapper {
        public int SubtitleStreamId { get; set; }
        public SubtitleStreamTableEntry SubtitleStream { get; set; }
    }
}
