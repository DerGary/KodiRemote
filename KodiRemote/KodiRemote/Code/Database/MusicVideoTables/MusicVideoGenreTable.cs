
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideoGenres")]
    public class MusicVideoGenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int genreid { get; set; }
        public int musicvideoid { get; set; }
    }
}
