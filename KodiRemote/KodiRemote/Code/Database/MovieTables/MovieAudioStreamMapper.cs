
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {
    public class MovieAudioStreamMapper : MovieMapper {
        public int AudioStreamId { get; set; }
        public AudioStreamTableEntry AudioStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId + ";" + AudioStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieAudioStreamMapper);
        }

        public bool Equals(MovieAudioStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MovieId == other.MovieId
                && AudioStreamId == other.AudioStreamId;
        }

        public override int GetHashCode() {
            return MovieId ^ AudioStreamId;
        }
    }
}
