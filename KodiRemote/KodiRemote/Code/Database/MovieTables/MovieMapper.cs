using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public abstract class MovieMapper : TableEntryBase {
        public int MovieId { get; set; }
        public MovieTableEntry Movie { get; set; }
    }
}
