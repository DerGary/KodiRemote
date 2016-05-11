
using KodiRemote.Code.Database.EpisodeTables;
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
    public class AudioStreamTableEntry {
        [Key]
        public int AudioStreamId { get; set; }
        public int Channels { get; set; }
        public string Codec { get; set; }
        public string Language { get; set; }

        public List<EpisodeAudioStreamMapper> Episodes { get; set; }

        public AudioStreamTableEntry() {}
        public AudioStreamTableEntry(AudioStream stream) {
            Channels = stream.Channels;
            Codec = stream.Codec;
            Language = stream.Language;
        }
    }
}
