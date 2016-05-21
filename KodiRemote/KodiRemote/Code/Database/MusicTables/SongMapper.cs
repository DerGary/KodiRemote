using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public abstract class SongMapper : TableEntryBase {
        public int SongId { get; set; }
        public SongTableEntry Song { get; set; }
    }
}
