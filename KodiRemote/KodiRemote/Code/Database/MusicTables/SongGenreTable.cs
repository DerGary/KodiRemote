
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("SongGenres")]
    public class SongGenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int songid { get; set; }
        public int genreid { get; set; }
    }
}
