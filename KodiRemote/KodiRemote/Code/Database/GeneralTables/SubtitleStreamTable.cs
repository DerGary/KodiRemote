using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("SubtitleStreams")]
    public class SubtitleStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int subtitlestreamid { get; set; }
        public string language { get; set; }
    }
}
