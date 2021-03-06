﻿using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeAudioStreamMapper : EpisodeMapper {
        public int AudioStreamId { get; set; }
        public AudioStreamTableEntry AudioStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId + ";" + AudioStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeAudioStreamMapper);
        }

        public bool Equals(EpisodeAudioStreamMapper other) {
            if((object) other == null) {
                return false;
            }
            return EpisodeId == other.EpisodeId
                && AudioStreamId == other.AudioStreamId;
        }

        public override int GetHashCode() {
            return EpisodeId ^ AudioStreamId;
        }
    }
}
