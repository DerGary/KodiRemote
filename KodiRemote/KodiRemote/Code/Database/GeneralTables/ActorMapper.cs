using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {
    public abstract class ActorMapper : TableEntryBase {
        public int ActorId { get; set; }
        public ActorTableEntry Actor { get; set; }

        public string Role { get; set; }
    }
}
