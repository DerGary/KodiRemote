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
    [Table("Artists")]
    public class ArtistTableEntry : TableEntryWithLabelBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtistId { get; set; }
        public string Artist { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string Fanart { get; set; }
        public string Description { get; set; }
        public string Formed { get; set; }
        public string Thumbnail { get; set; }

        public List<AlbumArtistMapper> Albums { get; set; }
        public List<SongArtistMapper> Songs { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return ArtistId.ToString();
            }
        }

        public ArtistTableEntry() {}
        public ArtistTableEntry(int artistid, string artist, string born, string died, string fanart, string description, string label, string formed, string thumbnail) {
            update(artistid, artist, born, died, fanart, description, label, formed, thumbnail);
        }
        public ArtistTableEntry(Artist artist) {
            update(artist);
        }
        public void update(Artist artist) {
            update(artist.ArtistId, artist.ArtistName, artist.Born, artist.Died, artist.Fanart, artist.Description, artist.Label, artist.Formed, artist.Thumbnail);
        }
        public void update(int artistid, string artist, string born, string died, string fanart, string description, string label, string formed, string thumbnail) {
            this.ArtistId = artistid;
            this.Artist = artist;
            this.Born = born;
            this.Fanart = fanart;
            this.Description = description;
            this.Label = label;
            this.Formed = formed;
            this.Thumbnail = thumbnail;
            this.Died = died;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as ArtistTableEntry);
        }

        public bool Equals(ArtistTableEntry other) {
            if((object)other == null) {
                return false;
            }

            return IsKeyEqual(other)
                && Artist == other.Artist
                && Born == other.Born
                && Fanart == other.Fanart
                && Description == other.Description
                && Label == other.Label
                && Formed == other.Formed
                && Thumbnail == other.Thumbnail
                && Died == other.Died;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as ArtistTableEntry;
            return ArtistId == obj?.ArtistId;
        }

        public override int GetHashCode() {
            return ArtistId;
        }
    }
}
