using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieGenres")]
    public class MovieGenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int movieid { get; set; }
        public int genreid { get; set; }
    }
}
