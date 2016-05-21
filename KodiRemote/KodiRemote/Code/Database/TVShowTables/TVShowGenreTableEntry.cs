﻿using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowGenres")]
    public class TVShowGenreTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }
        [Required]
        public string Genre { get; set; }

        public List<TVShowGenreMapper> TVShows { get; set; } = new List<TVShowGenreMapper>();

        [NotMapped]
        public override string Key {
            get {
                return Genre;
            }
        }

        public TVShowGenreTableEntry() { }
        public TVShowGenreTableEntry(string genre) : this() {
            Genre = genre;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as TVShowGenreTableEntry);
        }

        public bool Equals(TVShowGenreTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return Genre == other.Genre;
        }

        public override int GetHashCode() {
            return Genre.GetHashCode();
        }
    }
}