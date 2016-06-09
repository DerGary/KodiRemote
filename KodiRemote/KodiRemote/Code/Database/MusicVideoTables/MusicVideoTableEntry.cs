using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {
    [Table("MusicVideos")]
    public class MusicVideoTableEntry : TableEntryWithLabelBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MusicVideoId { get; set; }
        public string Album { get; set; }
        public string Poster { get; set; }
        public int PlayCount { get; set; }
        public string Plot { get; set; }
        public int Runtime { get; set; }
        public string Thumbnail { get; set; }
        public int Year { get; set; }
        public int Track { get; set; }
        public string Fanart { get; set; }
        public string DateAdded { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return MusicVideoId.ToString();
            }
        }

        public List<MusicVideoAudioStreamMapper> AudioStreams { get; set; }
        public List<MusicVideoArtistMapper> Artists { get; set; }
        public List<MusicVideoDirectorMapper> Directors{ get; set; }
        public List<MusicVideoGenreMapper> Genres { get; set; }
        public List<MusicVideoSubtitleStreamMapper> SubtitleStreams { get; set; }
        public List<MusicVideoVideoStreamMapper> VideoStreams { get; set; }

        public MusicVideoTableEntry() {}
        public MusicVideoTableEntry(string album, string poster, string label, int musicvideoid, int playcount, string plot, int runtime, string thumbnail, int year, int track, string fanart, string dateadded) {
            update(album, poster, label, musicvideoid, playcount, plot, runtime, thumbnail, year, track, fanart, dateadded);
        }
        public MusicVideoTableEntry(MusicVideo mvideo) {
            update(mvideo);
        }
        public void update(MusicVideo mvideo) {
            update(mvideo.Album, mvideo.Art.Poster, mvideo.Label, mvideo.MusicVideoId, mvideo.PlayCount, mvideo.Plot, mvideo.Runtime, mvideo.Thumbnail, mvideo.Year, mvideo.Track, mvideo.Fanart, mvideo.DateAdded);
        }
        public void update(string album, string poster, string label, int musicvideoid, int playcount, string plot, int runtime, string thumbnail, int year, int track, string fanart, string dateadded) {
            this.Album = album;
            this.Poster = poster;
            this.Label = label;
            this.MusicVideoId = musicvideoid;
            this.PlayCount = playcount;
            this.Plot = plot;
            this.Runtime = runtime;
            this.Thumbnail = thumbnail;
            this.Year = year;
            this.Track = track;
            this.Fanart = fanart;
            this.DateAdded = dateadded;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoTableEntry);
        }

        public bool Equals(MusicVideoTableEntry other) {
            if((object) other == null) {
                return false;
            }

            return IsKeyEqual(other)
                && Album == other.Album
                && Poster == other.Poster
                && Label == other.Label
                && PlayCount == other.PlayCount
                && Plot == other.Plot
                && Runtime == other.Runtime
                && Thumbnail == other.Thumbnail
                && Year == other.Year
                && Track == other.Track
                && Fanart == other.Fanart
                && DateAdded == other.DateAdded;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as MusicVideoTableEntry;
            return MusicVideoId == obj?.MusicVideoId;
        }

        public override int GetHashCode() {
            return MusicVideoId;
        }
    }
}
