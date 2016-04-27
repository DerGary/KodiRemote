using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowActors")]
    public class TVShowActorsTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int tvshowid { get; set; }
        public int actorid { get; set; }
        public string role { get; set; }
    }
}
