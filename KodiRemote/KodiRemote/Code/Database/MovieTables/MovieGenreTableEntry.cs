
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieGenres")]
    public class MovieGenreTableEntry : GenreTableEntry {
        public List<MovieGenreMapper> Movies { get; set; } = new List<MovieGenreMapper>();
        
        public MovieGenreTableEntry() { }
        public MovieGenreTableEntry(string genre) : this() {
            Genre = genre;
        }
    }
}
