using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.EpisodeTables {

    [Table("Episodes")]
    public class EpisodeTableEntry : TableEntryBase {
        [Key]
        public int EpisodeId { get; set; }
        public int Episode { get; set; }
        public int TVShowId { get; set; }
        public int Season { get; set; }
        public float Rating { get; set; }
        public string Plot { get; set; }
        public int PlayCount { get; set; }
        public int Runtime { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string DateAdded { get; set; }

        
        public List<EpisodeActorMapper> Actors { get; set; }
        public List<EpisodeAudioStreamMapper> AudioStreams { get; set; }
        public List<EpisodeDirectorMapper> Directors { get; set; }
        public List<EpisodeSubtitleStreamMapper> SubtitleStreams{ get; set; }
        public List<EpisodeVideoStreamMapper> VideoStreams { get; set; }

        public TVShowSeasonTableEntry TVShowSeason { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return EpisodeId.ToString();
            }
        }

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
            this.Episode = episode;
            this.EpisodeId = episodeid;
            this.PlayCount = playcount;
            this.Plot = plot;
            this.Rating = rating;
            this.Runtime = runtime;
            this.Season = season +1;
            this.Thumbnail = thumbnail;
            this.TVShowId = tvshowid;
            this.Title = title;
            this.DateAdded = dateadded;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as EpisodeTableEntry);
        }
        public bool Equals(EpisodeTableEntry obj) {
            if((object)obj == null) {
                return false;
            }

            return IsKeyEqual(obj) 
                && Episode == obj.Episode 
                && PlayCount == obj.PlayCount
                && Plot == obj.Plot
                && Rating == obj.Rating
                && Runtime == obj.Runtime
                && Season == obj.Season
                && Thumbnail == obj.Thumbnail
                && TVShowId == obj.TVShowId
                && Title == obj.Title
                && DateAdded == obj.DateAdded;
        }
        public override int GetHashCode() {
            return EpisodeId;
        }
        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as EpisodeTableEntry;
            if(obj == null) {
                return false;
            }
            return EpisodeId == obj.EpisodeId;
        }
    }
}
