using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeDirectorMapper : EpisodeMapper {
        public int DirectorId { get; set; }
        public DirectorTableEntry Director { get; set; }
    }
}
