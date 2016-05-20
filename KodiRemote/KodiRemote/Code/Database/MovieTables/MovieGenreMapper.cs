using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieGenreMapper : MovieMapper {
        public int GenreId { get; set; }
        public MovieGenreTableEntry Genre { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + GenreId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieGenreMapper);
        }

        public bool Equals(MovieGenreMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return MovieId == other.MovieId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return MovieId ^ GenreId;
        }
    }
}
