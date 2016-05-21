using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    public abstract class AlbumMapper : TableEntryBase {
        public int AlbumId { get; set; }
        public AlbumTableEntry Album { get; set; }
    }
}
