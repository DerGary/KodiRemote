using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("AudioPlaylists")]
    public class AudioPlaylistTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int playlistid { get; set; }
    }
}
