using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeActorMapper : EpisodeMapper {
        public int ActorId { get; set; }
        public ActorTableEntry Actor { get; set; }

        public string Role { get; set; }
    }
}
