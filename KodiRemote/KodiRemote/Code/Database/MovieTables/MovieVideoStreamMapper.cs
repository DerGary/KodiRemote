
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieVideoStreamMapper : MovieMapper {
        public int VideoStreamId { get; set; }
        public VideoStreamTableEntry VideoStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + VideoStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieVideoStreamMapper);
        }
        public bool Equals(MovieVideoStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return VideoStreamId == other.VideoStreamId
                && MovieId == other.MovieId;
        }
        public override int GetHashCode() {
            return MovieId ^ VideoStreamId;
        }
    }
}
