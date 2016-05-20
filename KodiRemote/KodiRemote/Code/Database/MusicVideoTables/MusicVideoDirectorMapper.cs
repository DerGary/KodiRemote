
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoDirectorMapper : MusicVideoMapper {
        public int DirectorId { get; set; }
        public DirectorTableEntry Director { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + DirectorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoDirectorMapper);
        }

        public bool Equals(MusicVideoDirectorMapper other) {
            if ((object)other == null) {
                return false;
            }
            return MusicVideoId == other.MusicVideoId
                && DirectorId == other.DirectorId;
        }

        public override int GetHashCode() {
            return MusicVideoId ^ DirectorId;
        }
    }
}
