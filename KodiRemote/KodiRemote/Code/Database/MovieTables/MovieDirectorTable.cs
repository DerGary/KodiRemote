using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieDirectors")]
    public class MovieDirectorTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int movieid { get; set; }
        public int directorid { get; set; }
    }
}
