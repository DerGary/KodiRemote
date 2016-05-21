using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("Movies")]
    public class MovieTableEntry : TableEntryBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }
        public string Label { get; set; }
        public int SetId { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Trailer { get; set; }
        public string IMDBNumber { get; set; }
        public float Rating { get; set; }
        public int PlayCount { get; set; }
        public int Runtime { get; set; }
        public int Year { get; set; }
        public string DateAdded { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MovieId.ToString();
            }
        }

        public List<MovieMovieSetMapper> MovieSets { get; set; }
        public List<MovieActorMapper> Actors { get; set; }
        public List<MovieAudioStreamMapper> AudioStreams { get; set; }
        public List<MovieDirectorMapper> Directors{ get; set; }
        public List<MovieGenreMapper> Genres { get; set; }
        public List<MovieSubtitleStreamMapper> SubtitleStreams { get; set; }
        public List<MovieVideoStreamMapper> VideoStreams{ get; set; }

        public MovieTableEntry() {

        }
        public MovieTableEntry(int movieid, string label, int setid, string fanart, string poster, string plot, string trailer, string imdbnumber, float rating, int playcount, int runtime, int year, string dateadded) {
            update(movieid, label, setid, fanart, poster, plot, trailer, imdbnumber, rating, playcount, runtime, year, dateadded);
        }
        public MovieTableEntry(Movie movie) {
            update(movie);
        }
        public void update(Movie movie) {
            update(movie.MovieId, movie.Label, movie.SetId, movie.Art.Fanart, movie.Art.Poster, movie.Plot, movie.Trailer, movie.IMDBNumber, movie.Rating, movie.PlayCount, movie.Runtime, movie.Year, movie.DateAdded);
        }
        public void update(int movieid, string label, int setid, string fanart, string poster, string plot, string trailer, string imdbnumber, float rating, int playcount, int runtime, int year, string dateadded) {
            this.Fanart = fanart;
            this.IMDBNumber = imdbnumber;
            this.Label = label;
            this.MovieId = movieid;
            this.PlayCount = playcount;
            this.Plot = plot;
            this.Poster = poster;
            this.Rating = rating;
            this.Runtime = runtime;
            this.SetId = setid;
            this.Trailer = trailer;
            this.Year = year;
            this.DateAdded = dateadded;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieTableEntry);
        }

        public bool Equals(MovieTableEntry other) {
            if((object) other == null) {
                return false;
            }
            return IsKeyEqual(other)
                && Fanart == other.Fanart
                && IMDBNumber == other.IMDBNumber
                && Label == other.Label
                && PlayCount == other.PlayCount
                && Plot == other.Plot
                && Poster == other.Poster
                && Rating == other.Rating
                && Runtime == other.Runtime
                && SetId == other.SetId
                && Trailer == other.Trailer
                && Year == other.Year
                && DateAdded == other.DateAdded;
        }
        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as MovieTableEntry;
            return MovieId == obj?.MovieId;
        }

        public override int GetHashCode() {
            return MovieId;
        }
    }
}
