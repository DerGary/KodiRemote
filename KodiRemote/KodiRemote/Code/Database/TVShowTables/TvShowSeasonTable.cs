using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowSeasons")]
    public class TVShowSeasonTableEntry : IComparable {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int episode { get; set; }
        public int tvshowid { get; set; }
        public int watchedepisodes { get; set; }
        public int season { get; set; }
        public string banner { get; set; }
        public string poster { get; set; }
        public string label { get; set; }
        public TVShowSeasonTableEntry() {

        }
        public TVShowSeasonTableEntry(int episode, int tvshowid, int watchedepisodes, int season, string banner, string poster, string label) {
            update(episode, tvshowid, watchedepisodes, season, banner, poster, label);
        }
        public TVShowSeasonTableEntry(TVShowSeason season) {
            update(season);
        }
        public void update(TVShowSeason season) {
            update(season.Episode, season.TVShowId, season.WatchedEpisodes, season.Season, season.Art.Banner, season.Art.Poster, season.Label);
        }
        public void update(int episode, int tvshowid, int watchedepisodes, int season, string banner, string poster, string label) {
            this.episode = episode;
            this.tvshowid = tvshowid;
            this.watchedepisodes = watchedepisodes;
            this.season = season;
            this.banner = banner;
            this.poster = poster;
            this.label = label;
        }
        public int CompareTo(object obj) {
            return this.season.CompareTo(((TVShowSeasonTableEntry)obj).season);
        }
    }
}
