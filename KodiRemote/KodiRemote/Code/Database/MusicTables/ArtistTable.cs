using KodiRemote.Code.JSON.KAudioLibrary.Results;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("Artists")]
    public class ArtistTableEntry {
        [PrimaryKey]
        public int artistid { get; set; }
        public string artist { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public string fanart { get; set; }
        public string description { get; set; }
        public string label { get; set; }
        public string formed { get; set; }
        public string thumbnail { get; set; }
        public ArtistTableEntry() {

        }
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
            this.artistid = artistid;
            this.artist = artist;
            this.born = born;
            this.fanart = fanart;
            this.description = description;
            this.label = label;
            this.formed = formed;
            this.thumbnail = thumbnail;
            this.died = died;
        }
    }
}
