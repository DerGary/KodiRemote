using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeAudioStreamMapper : EpisodeMapper {
        public int AudioStreamId { get; set; }
        public AudioStreamTableEntry AudioStream { get; set; }
    }
}
