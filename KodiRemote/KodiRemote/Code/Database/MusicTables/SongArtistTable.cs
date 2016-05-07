using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("SongArtists")]
    public class SongArtistTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int songid { get; set; }
        public int artistid { get; set; }
    }
}
