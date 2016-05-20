using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public abstract class MusicVideoMapper : TableEntryBase{
        public int MusicVideoId { get; set; }
        public MusicVideoTableEntry MusicVideo { get; set; }
    }
}
