
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Directors")]
    public class DirectorsTableEntry {
        [PrimaryKey, AutoIncrement]
        public int directorid { get; set; }
        public string name { get; set; }
    }
}
