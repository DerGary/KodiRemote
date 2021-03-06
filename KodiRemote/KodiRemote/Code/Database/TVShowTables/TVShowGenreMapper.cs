﻿using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {
    public class TVShowGenreMapper : TableEntryBase {
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        public int GenreId { get; set; }
        public TVShowGenreTableEntry Genre { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return TVShowId + ";" + GenreId;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as TVShowGenreMapper);
        }

        public bool Equals(TVShowGenreMapper other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return TVShowId ^ GenreId;
        }
    }
}
