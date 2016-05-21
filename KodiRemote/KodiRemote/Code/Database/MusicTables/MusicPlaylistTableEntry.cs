
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    [Table("MusicPlaylists")]
    public class MusicPlaylistTableEntry : TableEntryBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaylistId { get; set; }

        public List<MusicPlaylistSongMapper> Songs { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return PlaylistId.ToString();
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicPlaylistTableEntry);
        }

        public bool Equals(MusicPlaylistTableEntry other) {
            if((object) other== null) {
                return false;
            }
            return PlaylistId == other.PlaylistId;
        }

        public override int GetHashCode() {
            return PlaylistId;
        }
    }
}
