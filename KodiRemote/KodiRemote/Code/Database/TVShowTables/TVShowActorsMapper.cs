using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {
    public class TVShowActorMapper {
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        public int ActorId { get; set; }
        public ActorTableEntry Actor { get; set; }

        public string Role { get; set; }
    }
}
