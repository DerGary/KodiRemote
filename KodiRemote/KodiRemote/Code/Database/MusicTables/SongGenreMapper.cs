
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public class SongGenreMapper : SongMapper {
        public int GenreId { get; set; }
        public MusicGenreTableEntry Genre { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SongId + ";" + GenreId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as SongGenreMapper);
        }

        public bool Equals(SongGenreMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return SongId == other.SongId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return SongId ^ GenreId;
        }
    }
}
