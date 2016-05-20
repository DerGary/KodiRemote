
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("SubtitleStreams")]
    public class SubtitleStreamTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubtitleStreamId { get; set; }
        public string Language { get; set; }

        public List<EpisodeSubtitleStreamMapper> Episodes { get; set; }
        public List<MovieSubtitleStreamMapper> Movies { get; set; }
        public List<MusicVideoSubtitleStreamMapper> MusicVideos { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return Language;
            }
        }

        public SubtitleStreamTableEntry() {}
        public SubtitleStreamTableEntry(SubtitleStream stream) {
            Language = stream.Language;
        }


        public override bool Equals(object obj) {
            return this.Equals(obj as SubtitleStreamTableEntry);
        }

        public bool Equals(SubtitleStreamTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return this.Language == other.Language;
        }

        public override int GetHashCode() {
            return Language.GetHashCode();
        }
    }
}
