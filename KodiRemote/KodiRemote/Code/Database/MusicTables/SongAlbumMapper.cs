using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class SongAlbumMapper : SongMapper {
        public int AlbumId { get; set; }
        public AlbumTableEntry Album { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SongId + ";" + AlbumId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as SongAlbumMapper);
        }

        public bool Equals(SongAlbumMapper other) {
            if((object)other == null) {
                return false;
            }
            return SongId == other.SongId && AlbumId == other.AlbumId;
        }

        public override int GetHashCode() {
            return SongId ^ AlbumId;
        }
    }
}
