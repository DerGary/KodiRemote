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
    [Table("Albums")]
    public class AlbumTableEntry : TableEntryWithLabelBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlbumId { get; set; }
        public string AlbumLabel { get; set; }
        public string Description { get; set; }
        public string DisplayArtist { get; set; }
        public string Fanart { get; set; }
        public int PlayCount { get; set; }
        public float Rating { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

        public List<AlbumArtistMapper> Artists { get; set; }
        public List<SongAlbumMapper> Songs { get; set; }
        public List<AlbumGenreMapper> Genres { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return AlbumId.ToString();
            }
        }

        public AlbumTableEntry() {}
        public AlbumTableEntry(int albumid, string albumlabel, string description, string displayartist, string fanart, string label, int playcount, float rating, string thumbnail, string title, string type, int year) {
            update(albumid, albumlabel, description, displayartist, fanart, label, playcount, rating, thumbnail, title, type, year);
        }
        public AlbumTableEntry(Album album) {
            update(album);
        }
        public void update(Album album) {
            update(album.AlbumId, album.AlbumLabel, album.Description, album.DisplayArtist, album.Fanart, album.Label, album.PlayCount, album.Rating, album.Thumbnail, album.Title, album.Type, album.Year);
        }
        public void update(int albumid, string albumlabel, string description, string displayartist, string fanart, string label, int playcount, float rating, string thumbnail, string title, string type, int year) {
            this.AlbumId = albumid;
            this.AlbumLabel = albumlabel;
            this.Description = description;
            this.DisplayArtist = displayartist;
            this.Fanart = fanart;
            this.Label = label;
            this.PlayCount = playcount;
            this.Rating = rating;
            this.Thumbnail = thumbnail;
            this.Title = title;
            this.Type = type;
            this.Year = year;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as AlbumTableEntry);
        }

        public bool Equals(AlbumTableEntry other) {
            if((object)other == null) {
                return false;
            }
            return IsKeyEqual(other)
                && AlbumLabel == other.AlbumLabel
                && Description == other.Description
                && DisplayArtist == other.DisplayArtist
                && Fanart == other.Fanart
                && Label == other.Label
                && PlayCount == other.PlayCount
                && Rating == other.Rating
                && Thumbnail == other.Thumbnail
                && Title == other.Title
                && Type == other.Type
                && Year == other.Year;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as AlbumTableEntry;
            return AlbumId == obj?.AlbumId;
        }

        public override int GetHashCode() {
            return AlbumId;
        }
    }
}
