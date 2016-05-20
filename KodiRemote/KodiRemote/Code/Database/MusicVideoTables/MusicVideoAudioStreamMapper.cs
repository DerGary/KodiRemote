
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoAudioStreamMapper : MusicVideoMapper {
        public int AudioStreamId { get; set; }
        public AudioStreamTableEntry AudioStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + AudioStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoAudioStreamMapper);
        }

        public bool Equals(MusicVideoAudioStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MusicVideoId == other.MusicVideoId
                && AudioStreamId == other.AudioStreamId;
        }

        public override int GetHashCode() {
            return MusicVideoId ^ AudioStreamId;
        }
    }
}
