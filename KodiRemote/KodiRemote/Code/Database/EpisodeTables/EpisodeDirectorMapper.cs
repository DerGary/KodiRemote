﻿using KodiRemote.Code.Database.GeneralTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {
    public class EpisodeDirectorMapper : EpisodeMapper {
        public int DirectorId { get; set; }
        public DirectorTableEntry Director { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId + ";" + DirectorId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeDirectorMapper);
        }

        public bool Equals(EpisodeDirectorMapper other) {
            if((object) other == null) {
                return false;
            }
            return EpisodeId == other.EpisodeId
                && DirectorId == other.DirectorId;
        }

        public override int GetHashCode() {
            return EpisodeId ^ DirectorId;
        }
    }
}
