using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {
    public class TVShowGenreMapper {
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        public int GenreId { get; set; }
        public TVShowGenreTableEntry Genre { get; set; }
    }
}
