using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowGenres")]
    public class TVShowGenreTableEntry {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TVShowId { get; set; }
        public int GenreId { get; set; }

        public TVShowGenreTableEntry() { }
        public TVShowGenreTableEntry(TVShow tvshow, GenreTableEntry genre) : this() {
            TVShowId = tvshow.TVShowId;
            GenreId = genre.GenreId;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowGenreTableEntry other = obj as TVShowGenreTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return TVShowId == other.TVShowId && GenreId == other.GenreId;
        }

        public bool Equals(TVShowGenreTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && GenreId == other.GenreId;
        }

        public override int GetHashCode() {
            return TVShowId.GetHashCode() ^ GenreId.GetHashCode();
        }
    }
}
