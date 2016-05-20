
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieSubtitleStreamMapper : MovieMapper {
        public int SubtitleStreamId { get; set; }
        public SubtitleStreamTableEntry SubtitleStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + SubtitleStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieSubtitleStreamMapper);
        }

        public bool Equals(MovieSubtitleStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MovieId == other.MovieId
                && SubtitleStreamId == other.SubtitleStreamId;
        }

        public override int GetHashCode() {
            return MovieId ^ SubtitleStreamId;
        }
    }
}
