using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    [Table("MusicGenres")]
    public class MusicGenreTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }
        [Required]
        public string Genre { get; set; }

        public List<SongGenreMapper> Songs { get; set; } = new List<SongGenreMapper>();
        public List<AlbumGenreMapper> Albums { get; set; } = new List<AlbumGenreMapper>();

        [NotMapped]
        public override string Key {
            get {
                return Genre;
            }
        }

        public MusicGenreTableEntry() { }
        public MusicGenreTableEntry(string genre) : this() {
            Genre = genre;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicGenreTableEntry);
        }

        public bool Equals(MusicGenreTableEntry other) {
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
