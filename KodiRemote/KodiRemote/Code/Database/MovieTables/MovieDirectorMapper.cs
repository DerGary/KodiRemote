
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieDirectorMapper : MovieMapper {
        public int DirectorId { get; set; }
        public DirectorTableEntry Director { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + DirectorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieDirectorMapper);
        }

        public bool Equals(MovieDirectorMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MovieId == other.MovieId
                && DirectorId == other.DirectorId;
        }

        public override int GetHashCode() {
            return MovieId ^ DirectorId;
        }
    }
}
