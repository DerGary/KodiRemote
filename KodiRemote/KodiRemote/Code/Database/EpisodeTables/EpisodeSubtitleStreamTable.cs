
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {

    [Table("EpisodeSubtitleStreams")]
    public class EpisodeSubtitleStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int episodeid { get; set; }
        public int subtitlestreamid { get; set; }
    }
}
