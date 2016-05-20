﻿using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeSubtitleStreamMapper : EpisodeMapper {
        public int SubtitleStreamId { get; set; }
        public SubtitleStreamTableEntry SubtitleStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId + ";" + SubtitleStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeSubtitleStreamMapper);
        }

        public bool Equals(EpisodeSubtitleStreamMapper other) {
            if((object) other == null) {
                return false;
            }
            return EpisodeId == other.EpisodeId
                && SubtitleStreamId == other.SubtitleStreamId;
        }

        public override int GetHashCode() {
            return EpisodeId ^ SubtitleStreamId;
        }
    }
}
