using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("AudioPlaylistSongs")]
    public class AudioPlaylistSongTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int playlistid { get; set; }
        public int songid { get; set; }
    }
}
