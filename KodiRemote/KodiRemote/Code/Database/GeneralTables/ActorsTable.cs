using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Actors")]
    public class ActorsTableEntry {
        [PrimaryKey, AutoIncrement]
        public int actorid { get; set; }
        public string name { get; set; }
        public string thumbnail { get; set; }
    }
}
