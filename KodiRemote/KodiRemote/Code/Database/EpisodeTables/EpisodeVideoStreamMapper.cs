using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeVideoStreamMapper : EpisodeMapper {
        public int VideoStreamId { get; set; }
        public VideoStreamTableEntry VideoStream { get; set; }
    }
}
