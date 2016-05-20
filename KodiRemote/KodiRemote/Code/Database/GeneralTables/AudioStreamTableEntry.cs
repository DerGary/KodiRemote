
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
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

    [Table("AudioStreams")]
    public class AudioStreamTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AudioStreamId { get; set; }
        public int Channels { get; set; }
        public string Codec { get; set; }
        public string Language { get; set; }

        public List<EpisodeAudioStreamMapper> Episodes { get; set; }
        public List<MovieAudioStreamMapper> Movies { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return Channels + ";" + Codec + ";" + Language;
            }
        }

        public AudioStreamTableEntry() {}
        public AudioStreamTableEntry(AudioStream stream) {
            Channels = stream.Channels;
            Codec = stream.Codec;
            Language = stream.Language;
        }


        public override bool Equals(object obj) {
            return this.Equals(obj as AudioStreamTableEntry);
        }

        public bool Equals(AudioStreamTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return Channels == other.Channels && Codec == other.Codec && Language == other.Language;
        }

        public override int GetHashCode() {
            return Channels.GetHashCode() ^ Codec.GetHashCode() ^ Language.GetHashCode();
        }
    }
}
