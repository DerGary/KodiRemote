
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("AlbumArtists")]
    public class AlbumArtistTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int artistid { get; set; }
        public int albumid { get; set; }
    }
}
