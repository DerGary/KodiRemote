
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieActorMapper : MovieMapper {
        public int ActorId { get; set; }
        public ActorTableEntry Actor { get; set; }

        public string Role { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + ActorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieActorMapper);
        }

        public bool Equals(MovieActorMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return MovieId == other.MovieId && ActorId == other.ActorId && Role == other.Role;
        }

        public override int GetHashCode() {
            return MovieId ^ ActorId;
        }
    }
}
