
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoArtistMapper : MusicVideoMapper {
        public int MusicVideoArtistId { get; set; }
        public MusicVideoArtistTableEntry MusicVideoArtist { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + MusicVideoArtistId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoArtistMapper);
        }

        public bool Equals(MusicVideoArtistMapper other) {
            if((object) other == null) {
                return false;
            }
            return MusicVideoId == other.MusicVideoId && MusicVideoArtistId == other.MusicVideoArtistId;
        }

        public override int GetHashCode() {
            return MusicVideoId ^ MusicVideoArtistId;
        }
    }
}
