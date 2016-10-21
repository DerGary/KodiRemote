using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.MovieTables;

namespace KodiRemote.ViewModel.Video {
    public class MovieViewModel : ItemViewModel {
        public float Rating { get; set; }
        public int Runtime { get; set; }
        public List<MovieGenreMapper> Genres { get; set; }
        public MovieViewModel(MovieTableEntry item) : base(item) {
            Runtime = item.Runtime;
            Rating = item.Rating;
            Genres = item.Genres;
        }
    }
}
