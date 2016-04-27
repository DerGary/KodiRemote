using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Genres")]
    public class GenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int genreid { get; set; }
        public string genrelabel { get; set; }
        public string type { get; set; }
    }
}
