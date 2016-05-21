
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class SongArtistMapper : SongMapper {
        public int ArtistId { get; set; }
        public ArtistTableEntry Artist { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SongId + ";" + ArtistId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as SongArtistMapper);
        }

        public bool Equals(SongArtistMapper other) {
            if ((object)other == null) {
                return false;
            }
            return SongId == other.SongId && ArtistId == other.ArtistId;
        }

        public override int GetHashCode() {
            return SongId ^ ArtistId;
        }
    }
}
