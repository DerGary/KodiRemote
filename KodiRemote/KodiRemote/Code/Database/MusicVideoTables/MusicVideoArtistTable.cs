using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideoArtists")]
    public class MusicVideoArtistTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int musicvideoid { get; set; }
        public int mvartistid { get; set; }
    }
}
