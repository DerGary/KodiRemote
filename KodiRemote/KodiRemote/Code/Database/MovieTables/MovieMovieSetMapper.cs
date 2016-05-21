using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieMovieSetMapper : MovieMapper {
        public int MovieSetId { get; set; }
        public MovieSetTableEntry MovieSet { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + MovieSetId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieMovieSetMapper);
        }

        public bool Equals(MovieMovieSetMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return MovieId == other.MovieId && MovieSetId == other.MovieSetId;
        }

        public override int GetHashCode() {
            return MovieId ^ MovieSetId;
        }
    }
}
