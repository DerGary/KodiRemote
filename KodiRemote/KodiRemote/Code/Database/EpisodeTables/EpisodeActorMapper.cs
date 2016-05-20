using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeActorMapper : EpisodeMapper {
        public int ActorId { get; set; }
        public ActorTableEntry Actor { get; set; }

        public string Role { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId + ";" + ActorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeActorMapper);
        }

        public bool Equals(EpisodeActorMapper other) {
            if((object)other == null) {
                return false;
            }
            return EpisodeId == other.EpisodeId
                && ActorId == other.ActorId
                && Role == other.Role;
        }

        public override int GetHashCode() {
            return EpisodeId ^ ActorId;
        }
    }
}
