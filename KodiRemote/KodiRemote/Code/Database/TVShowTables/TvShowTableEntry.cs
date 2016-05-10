using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShows")]
    public class TVShowTableEntry {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TVShowId { get; set; }
        public int Episode { get; set; }
        public int WatchedEpisodes { get; set; }
        public float Rating { get; set; }
        public string Banner { get; set; }
        public string Poster { get; set; }
        public string Fanart { get; set; }
        public string Label { get; set; }
        public string Plot { get; set; }
        public string IMDBNumber { get; set; }
        public string DateAdded { get; set; }

        public List<TVShowGenreMapper> Genres { get; set; }
        public List<TVShowActorMapper> Actors { get; set; }
        public List<TVShowSeasonTableEntry> Seasons { get; set; }

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
            this.Episode = episode;
            this.TVShowId = tvshowid;
            this.WatchedEpisodes = watchedepisodes;
            this.Rating = rating;
            this.Banner = banner;
            this.Poster = poster;
            this.Fanart = fanart;
            this.Label = label;
            this.Plot = plot;
            this.IMDBNumber = imdbnumber;
            this.DateAdded = dateadded;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowTableEntry other = obj as TVShowTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return TVShowId == other.TVShowId;
        }

        public bool Equals(TVShowSeasonTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId;
        }

        public override int GetHashCode() {
            return TVShowId.GetHashCode();
        }
    }
}
