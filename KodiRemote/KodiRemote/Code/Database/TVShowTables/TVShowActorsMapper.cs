using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {
    public class TVShowActorMapper : ActorMapper {
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return TVShowId + ";" + ActorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as TVShowActorMapper);
        }

        public bool Equals(TVShowActorMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && ActorId == other.ActorId && Role == other.Role;
        }

        public override int GetHashCode() {
            return TVShowId ^ ActorId;
        }
    }
}
