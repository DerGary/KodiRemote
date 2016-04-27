using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideos")]
    public class MusicVideoTableEntry {
        [PrimaryKey]
        public int musicvideoid { get; set; }
        public string album { get; set; }
        public string poster { get; set; }
        public string label { get; set; }
        public int playcount { get; set; }
        public string plot { get; set; }
        public int runtime { get; set; }
        public string thumbnail { get; set; }
        public int year { get; set; }
        public int track { get; set; }
        public string fanart { get; set; }
        public string dateadded { get; set; }
        public MusicVideoTableEntry() {

        }
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
            this.album = album;
            this.poster = poster;
            this.label = label;
            this.musicvideoid = musicvideoid;
            this.playcount = playcount;
            this.plot = plot;
            this.runtime = runtime;
            this.thumbnail = thumbnail;
            this.year = year;
            this.track = track;
            this.fanart = fanart;
            this.dateadded = dateadded;
        }
    }
}
