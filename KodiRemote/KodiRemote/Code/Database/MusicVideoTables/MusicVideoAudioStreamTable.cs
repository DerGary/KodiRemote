using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideoAudioStreams")]
    public class MusicVideoAudioStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int audiostreamid { get; set; }
        public int musicvideoid { get; set; }
    }
}
