
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class AlbumArtistMapper : AlbumMapper {
        public int ArtistId { get; set; }
        public ArtistTableEntry Artist { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return AlbumId + ";" + ArtistId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as AlbumArtistMapper);
        }

        public bool Equals(AlbumArtistMapper other) {
            if ((object)other == null) {
                return false;
            }
            return AlbumId == other.AlbumId && ArtistId == other.ArtistId;
        }

        public override int GetHashCode() {
            return AlbumId ^ ArtistId;
        }
    }
}
