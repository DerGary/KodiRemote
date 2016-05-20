using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.Utils;
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
    public class TVShowSeasonTableEntry : TableEntryBase {
        [ForeignKey("TVShow")]
        public int TVShowId { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public int WatchedEpisodes { get; set; }
        public string Banner { get; set; }
        public string Poster { get; set; }
        public string Label { get; set; }

        public TVShowTableEntry TVShow { get; set; }
        public List<EpisodeTableEntry> Episodes { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return TVShowId + ";" + Season;
            }
        }

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
            this.Season = season +1;
            this.Banner = banner;
            this.Poster = poster;
            this.Label = label;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as TVShowSeasonTableEntry);
        }

        public bool Equals(TVShowSeasonTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }
            return IsKeyEqual(other)
                && Episode == other.Episode
                && WatchedEpisodes == other.WatchedEpisodes
                && Banner == other.Banner
                && Poster == other.Poster
                && Label == other.Label;
        }

        public override int GetHashCode() {
            return TVShowId ^ Season;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as TVShowSeasonTableEntry;
            if(obj == null) {
                return false;
            }
            return TVShowId == obj.TVShowId && Season == obj.Season;
        }
    }
}
