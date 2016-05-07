using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {
    public enum GenreType {
        MusicVideo, Movie, TVShow, Song, Artist, Album, MovieSet
    }
    [Table("Genres")]
    public class GenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int GenreId { get; set; }
        public string Label { get; set; }
        public GenreType Type { get; set; }

        public GenreTableEntry() { }
        public GenreTableEntry(string genre, GenreType type) {
            this.Label = genre;
            this.Type = type;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            GenreTableEntry other = obj as GenreTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return Label == other.Label && Type == other.Type;
        }

        public bool Equals(GenreTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return Label == other.Label && Type == other.Type;
        }

        public override int GetHashCode() {
            return Label.GetHashCode() ^ Type.GetHashCode();
        }
    }
}
