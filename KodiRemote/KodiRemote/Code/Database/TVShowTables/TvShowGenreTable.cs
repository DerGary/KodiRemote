using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowGenres")]
    public class TVShowGenreTableEntry {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Genre { get; set; }

        public List<TVShowGenre> TVShows { get; set; } = new List<TVShowGenre>();

        public TVShowGenreTableEntry() { }
        public TVShowGenreTableEntry(string genre) : this() {
            Genre = genre;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowGenreTableEntry other = obj as TVShowGenreTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return Genre == other.Genre;
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

    public class TVShowGenre {
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        public int GenreId { get; set; }
        public TVShowGenreTableEntry Genre { get; set; }
    }
}
