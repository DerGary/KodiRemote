using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShows")]
    public class TVShowTableEntry : IComparable {
        [PrimaryKey]
        public int tvshowid { get; set; }
        public int episode { get; set; }
        public int watchedepisodes { get; set; }
        public float rating { get; set; }
        public string banner { get; set; }
        public string poster { get; set; }
        public string fanart { get; set; }
        public string label { get; set; }
        public string plot { get; set; }
        public string imdbnumber { get; set; }
        public string dateadded { get; set; }
        public TVShowTableEntry() {

        }
        public TVShowTableEntry(int episode, int tvshowid, int watchedepisodes, float rating, string banner, string poster, string fanart, string label, string plot, string imdbnumber, string dateadded) {
            update(episode, tvshowid, watchedepisodes, rating, banner, poster, fanart, label, plot, imdbnumber, dateadded);
        }
        public TVShowTableEntry(TVShow tvshow) {
            update(tvshow);
        }
        public void update(TVShow tvshow) {
            update(tvshow.Episode, tvshow.TVShowId, tvshow.WatchedEpisodes, tvshow.Rating, tvshow.Art.Banner, tvshow.Art.Poster, tvshow.Art.Fanart, tvshow.Label, tvshow.Plot, tvshow.IMDBNumber, tvshow.DateAdded);
        }
        public void update(int episode, int tvshowid, int watchedepisodes, float rating, string banner, string poster, string fanart, string label, string plot, string imdbnumber, string dateadded) {
            this.episode = episode;
            this.tvshowid = tvshowid;
            this.watchedepisodes = watchedepisodes;
            this.rating = rating;
            this.banner = banner;
            this.poster = poster;
            this.fanart = fanart;
            this.label = label;
            this.plot = plot;
            this.imdbnumber = imdbnumber;
            this.dateadded = dateadded;
        }
        public int CompareTo(object obj) {
            return this.label.CompareTo(((TVShowTableEntry)obj).label);
        }
    }
}
