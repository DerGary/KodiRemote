using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {

    [Table("Episodes")]
    public class EpisodeTableEntry : IComparable {
        [PrimaryKey]
        public int episodeid { get; set; }
        public int episode { get; set; }
        public int tvshowid { get; set; }
        public int season { get; set; }
        public float rating { get; set; }
        public string plot { get; set; }
        public int playcount { get; set; }
        public int runtime { get; set; }
        public string thumbnail { get; set; }
        public string title { get; set; }
        public string dateadded { get; set; }
        public EpisodeTableEntry() {

        }
        public EpisodeTableEntry(int episodeid, int episode, int tvshowid, int season, float rating, string plot, int playcount, int runtime, string thumbnail, string title, string dateadded) {
            update(episodeid, episode, tvshowid, season, rating, plot, playcount, runtime, thumbnail, title, dateadded);
        }
        public EpisodeTableEntry(Episode episode) {
            update(episode);
        }
        public void update(Episode episode) {
            update(episode.EpisodeId, episode.EpisodeNumber, episode.TVShowId, episode.Season, episode.Rating, episode.Plot, episode.PlayCount, episode.Runtime, episode.Thumbnail, episode.Title, episode.DateAdded);
        }
        public void update(int episodeid, int episode, int tvshowid, int season, float rating, string plot, int playcount, int runtime, string thumbnail, string title, string dateadded) {
            this.episode = episode;
            this.episodeid = episodeid;
            this.playcount = playcount;
            this.plot = plot;
            this.rating = rating;
            this.runtime = runtime;
            this.season = season;
            this.thumbnail = thumbnail;
            this.tvshowid = tvshowid;
            this.title = title;
            this.dateadded = dateadded;
        }

        public int CompareTo(object obj) {
            return this.episode.CompareTo(((EpisodeTableEntry)obj).episode);
        }
    }
}
