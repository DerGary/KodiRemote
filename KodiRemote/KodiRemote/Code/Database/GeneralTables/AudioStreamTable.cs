using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("AudioStreams")]
    public class AudioStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int audiostreamid { get; set; }
        public int channels { get; set; }
        public string codec { get; set; }
        public string language { get; set; }
    }
}
