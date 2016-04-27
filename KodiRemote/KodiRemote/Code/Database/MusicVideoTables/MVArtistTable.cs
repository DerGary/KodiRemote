using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MVArtists")]
    public class MVArtistTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
    }
}
