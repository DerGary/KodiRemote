
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieSetMovies")]
    public class MovieSetMovieTableEntry {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int setid { get; set; }
        public int movieid { get; set; }
        public MovieSetMovieTableEntry() {
        }
        public MovieSetMovieTableEntry(int movieid, int setid) {
            update(movieid, setid);
        }
        public MovieSetMovieTableEntry(MovieSetMovieTableEntry movieset) {
            update(movieset);
        }
        public void update(MovieSetMovieTableEntry movieset) {
            update(movieset.movieid, movieset.setid);
        }
        public void update(int movieid, int setid) {
            this.setid = setid;
            this.movieid = movieid;
        }
    }
}
