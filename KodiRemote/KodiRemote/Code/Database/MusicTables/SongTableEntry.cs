using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KAudioLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {
    [Table("Songs")]
    public class SongTableEntry : TableEntryWithLabelBase {
        [Key]
        public int SongId { get; set; }
        public int AlbumId { get; set; }
        public string Album { get; set; }
        public string Comment { get; set; }
        public string DisplayArtist { get; set; }
        public int Duration { get; set; }
        public string Fanart { get; set; }
        public int PlayCount { get; set; }
        public float Rating { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public int Track { get; set; }
        public int Year { get; set; }

        public List<SongGenreMapper> Genres { get; set; }
        public List<SongAlbumMapper> Albums { get; set; }
        public List<SongArtistMapper> Artists { get; set; }
        public List<MusicPlaylistSongMapper> Playlists { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SongId.ToString();
            }
        }

        public SongTableEntry() {}
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
            this.Album = album;
            this.AlbumId = albumid;
            this.Comment = comment;
            this.DisplayArtist = displayartist;
            this.Duration = duration;
            this.Fanart = fanart;
            this.Label = label;
            this.PlayCount = playcount;
            this.Rating = rating;
            this.SongId = songid;
            this.Thumbnail = thumbnail;
            this.Title = title;
            this.Track = track;
            this.Year = year;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as SongTableEntry);
        }

        public bool Equals(SongTableEntry other) {
            if((object) other == null) {
                return false;
            }

            return IsKeyEqual(other)
                && Album == other.Album
                && AlbumId == other.AlbumId
                && Comment == other.Comment
                && DisplayArtist == other.DisplayArtist
                && Duration == other.Duration
                && Fanart == other.Fanart
                && Label == other.Label
                && PlayCount == other.PlayCount
                && Rating == other.Rating
                && Thumbnail == other.Thumbnail
                && Title == other.Title
                && Track == other.Track
                && Year == other.Year;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as SongTableEntry;
            return SongId == obj?.SongId;
        }

        public override int GetHashCode() {
            return SongId;
        }
    }

}
