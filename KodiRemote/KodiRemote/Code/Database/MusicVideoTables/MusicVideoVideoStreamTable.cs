﻿
using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    public class MusicVideoVideoStreamMapper : MusicVideoMapper {
        public int VideoStreamId { get; set; }
        public VideoStreamTableEntry VideoStream { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId + ";" + VideoStreamId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoVideoStreamMapper);
        }
        public bool Equals(MusicVideoVideoStreamMapper other) {
            if ((object)other == null) {
                return false;
            }
            return VideoStreamId == other.VideoStreamId
                && MusicVideoId == other.MusicVideoId;
        }
        public override int GetHashCode() {
            return MusicVideoId ^ VideoStreamId;
        }
    }
}
