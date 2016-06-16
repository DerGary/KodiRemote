using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {
    [Table("TVShowGenres")]
    public class TVShowGenreTableEntry : GenreTableEntry {

        public List<TVShowGenreMapper> TVShows { get; set; } = new List<TVShowGenreMapper>();

        public TVShowGenreTableEntry() { }
        public TVShowGenreTableEntry(string genre) : this() {
            Genre = genre;
        }
    }
}
