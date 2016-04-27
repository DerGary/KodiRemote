using KodiRemote.Code.JSON.KAudioLibrary.Results;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicTables {

    [Table("Albums")]
    public class AlbumTableEntry {
        [PrimaryKey]
        public int albumid { get; set; }
        public string albumlabel { get; set; }
        public string description { get; set; }
        public string displayartist { get; set; }
        public string fanart { get; set; }
        public string label { get; set; }
        public int playcount { get; set; }
        public float rating { get; set; }
        public string thumbnail { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public AlbumTableEntry() {

        }
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
            this.albumid = albumid;
            this.albumlabel = albumlabel;
            this.description = description;
            this.displayartist = displayartist;
            this.fanart = fanart;
            this.label = label;
            this.playcount = playcount;
            this.rating = rating;
            this.thumbnail = thumbnail;
            this.title = title;
            this.type = type;
            this.year = year;
        }
    }
}
