
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoSubtitleStreamMapper : MusicVideoMapper {
        public int SubtitleStreamId { get; set; }
        public SubtitleStreamTableEntry SubtitleStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + SubtitleStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoSubtitleStreamMapper);
        }

        public bool Equals(MusicVideoSubtitleStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MusicVideoId == other.MusicVideoId
                && SubtitleStreamId == other.SubtitleStreamId;
        }

        public override int GetHashCode() {
            return MusicVideoId ^ SubtitleStreamId;
        }
    }
}
