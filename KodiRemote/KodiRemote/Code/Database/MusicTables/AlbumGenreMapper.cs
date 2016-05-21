
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class AlbumGenreMapper : AlbumMapper {
        public int GenreId { get; set; }
        public MusicGenreTableEntry Genre { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return AlbumId + ";" + GenreId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as AlbumGenreMapper);
        }

        public bool Equals(AlbumGenreMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return AlbumId == other.AlbumId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return AlbumId ^ GenreId;
        }
    }
}
