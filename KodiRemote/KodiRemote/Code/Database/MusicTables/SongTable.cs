using KodiRemote.Code.JSON.KAudioLibrary.Results;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("Songs")]
    public class SongTableEntry {
        [PrimaryKey]
        public int songid { get; set; }
        public int albumid { get; set; }
        public string album { get; set; }
        public string comment { get; set; }
        public string displayartist { get; set; }
        public int duration { get; set; }
        public string fanart { get; set; }
        public string label { get; set; }
        public int playcount { get; set; }
        public float rating { get; set; }
        public string thumbnail { get; set; }
        public string title { get; set; }
        public int track { get; set; }
        public int year { get; set; }
        public SongTableEntry() {

        }
        public SongTableEntry(string album, int albumid, string comment, string displayartist, int duration, string fanart, string label, int playcount, float rating, int songid, string thumbnail, string title, int track, int year) {
            update(album, albumid, comment, displayartist, duration, fanart, label, playcount, rating, songid, thumbnail, title, track, year);
        }
        public SongTableEntry(Song song) {
            update(song);
        }

        public void update(Song song) {
            update(song.Album, song.AlbumId, song.Comment, song.DisplayArtist, song.Duration, song.Fanart, song.Label, song.PlayCount, song.Rating, song.SongId, song.Thumbnail, song.Title, song.Track, song.Year);
        }

        public void update(string album, int albumid, string comment, string displayartist, int duration, string fanart, string label, int playcount, float rating, int songid, string thumbnail, string title, int track, int year) {
            this.album = album;
            this.albumid = albumid;
            this.comment = comment;
            this.displayartist = displayartist;
            this.duration = duration;
            this.fanart = fanart;
            this.label = label;
            this.playcount = playcount;
            this.rating = rating;
            this.songid = songid;
            this.thumbnail = thumbnail;
            this.title = title;
            this.track = track;
            this.year = year;
        }
    }

}
