using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideoDirectors")]
    public class MusicVideoDirectorTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int directorid { get; set; }
        public int musicvideoid { get; set; }
    }
}
