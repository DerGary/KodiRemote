using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieVideoStreams")]
    public class MovieVideoStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int movieid { get; set; }
        public int videostreamid { get; set; }
    }
}
