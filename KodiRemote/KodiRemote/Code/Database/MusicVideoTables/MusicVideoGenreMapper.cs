using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoGenreMapper : MusicVideoMapper {
        public int GenreId { get; set; }
        public MusicVideoGenreTableEntry Genre { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + GenreId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoGenreMapper);
        }

        public bool Equals(MusicVideoGenreMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return MusicVideoId == other.MusicVideoId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return MusicVideoId ^ GenreId;
        }
    }
}
