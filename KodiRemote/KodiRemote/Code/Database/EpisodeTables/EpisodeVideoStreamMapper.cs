﻿using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeVideoStreamMapper : EpisodeMapper {
        public int VideoStreamId { get; set; }
        public VideoStreamTableEntry VideoStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId + ";" + VideoStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeVideoStreamMapper);
        }
        public bool Equals(EpisodeVideoStreamMapper other) {
            if((object)other == null) {
                return false;
            }
            return VideoStreamId == other.VideoStreamId
                && EpisodeId == other.EpisodeId;
        }
        public override int GetHashCode() {
            return EpisodeId ^ VideoStreamId;
        }
    }
}
