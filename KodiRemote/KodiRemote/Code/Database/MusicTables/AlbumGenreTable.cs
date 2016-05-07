using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("AlbumGenres")]
    public class AlbumGenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int genreid { get; set; }
        public int albumid { get; set; }
    }
}
