using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("Movies")]
    public class MovieTableEntry : IComparable {
        [PrimaryKey]
        public int movieid { get; set; }
        public string label { get; set; }
        public int setid { get; set; }
        public string fanart { get; set; }
        public string poster { get; set; }
        public string plot { get; set; }
        public string trailer { get; set; }
        public string imdbnumber { get; set; }
        public float rating { get; set; }
        public int playcount { get; set; }
        public int runtime { get; set; }
        public int year { get; set; }
        public string dateadded { get; set; }
        public MovieTableEntry() {

        }
        public MovieTableEntry(int movieid, string label, int setid, string fanart, string poster, string plot, string trailer, string imdbnumber, float rating, int playcount, int runtime, int year, string dateadded) {
            update(movieid, label, setid, fanart, poster, plot, trailer, imdbnumber, rating, playcount, runtime, year, dateadded);
        }
        //public MovieTable(string movieid, string label, string setid, string fanart, string poster, string plot, string trailer, string imdbnumber, string rating, string playcount, string runtime, string year, string dateadded)
        //{
        //    this.fanart = fanart;
        //    this.imdbnumber = imdbnumber;
        //    this.label = label;
        //    this.movieid = Convert.ToInt32(movieid);
        //    this.playcount = Convert.ToInt32(playcount);
        //    this.plot = plot;
        //    this.poster = poster;
        //    this.rating = (float)Convert.ToDouble(rating);
        //    this.runtime = Convert.ToInt32(runtime);
        //    this.setid = Convert.ToInt32(setid);
        //    this.trailer = trailer;
        //    this.year = Convert.ToInt32(year);
        //    this.dateadded = dateadded;
        //}
        public MovieTableEntry(Movie movie) {
            update(movie);
        }
        public void update(Movie movie) {
            update(movie.MovieId, movie.Label, movie.SetId, movie.Art.Fanart, movie.Art.Poster, movie.Plot, movie.Trailer, movie.IMDBNumber, movie.Rating, movie.PlayCount, movie.Runtime, movie.Year, movie.DateAdded);
        }
        public void update(int movieid, string label, int setid, string fanart, string poster, string plot, string trailer, string imdbnumber, float rating, int playcount, int runtime, int year, string dateadded) {
            this.fanart = fanart;
            this.imdbnumber = imdbnumber;
            this.label = label;
            this.movieid = movieid;
            this.playcount = playcount;
            this.plot = plot;
            this.poster = poster;
            this.rating = rating;
            this.runtime = runtime;
            this.setid = setid;
            this.trailer = trailer;
            this.year = year;
            this.dateadded = dateadded;
        }
        public int CompareTo(object obj) {
            return this.label.CompareTo(((MovieTableEntry)obj).label);
        }
    }
}
