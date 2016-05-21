
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class MusicPlaylistSongMapper : SongMapper {
        public int PlaylistId { get; set; }
        public MusicPlaylistTableEntry Playlist { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SongId + ";" + PlaylistId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicPlaylistSongMapper);
        }

        public bool Equals(MusicPlaylistSongMapper other) {
            if ((object)other == null) {
                return false;
            }
            return SongId == other.SongId && PlaylistId == other.PlaylistId;
        }

        public override int GetHashCode() {
            return SongId ^ PlaylistId;
        }
    }
}
