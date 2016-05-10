using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowSeasons")]
    public class TVShowSeasonTableEntry {
        [ForeignKey("TVShow")]
        public int TVShowId { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public int WatchedEpisodes { get; set; }
        public string Banner { get; set; }
        public string Poster { get; set; }
        public string Label { get; set; }

        public TVShowTableEntry TVShow { get; set; }

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
            this.Episode = episode;
            this.TVShowId = tvshowid;
            this.WatchedEpisodes = watchedepisodes;
            this.Season = season;
            this.Banner = banner;
            this.Poster = poster;
            this.Label = label;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowSeasonTableEntry other = obj as TVShowSeasonTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return TVShowId == other.TVShowId && Season == other.Season;
        }

        public bool Equals(TVShowSeasonTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && Season == other.Season;
        }

        public override int GetHashCode() {
            return TVShowId.GetHashCode() ^ Season.GetHashCode();
        }

    }
}
