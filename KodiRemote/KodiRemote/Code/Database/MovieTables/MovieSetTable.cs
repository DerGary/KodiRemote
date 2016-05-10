using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieSets")]
    public class MovieSetTableEntry {
        [PrimaryKey]
        public int setid { get; set; }
        public string label { get; set; }
        public int playcount { get; set; }
        public string thumbnail { get; set; }
        public string fanart { get; set; }
        public string poster { get; set; }
        public MovieSetTableEntry() {
        }
        public MovieSetTableEntry(int setid, string label, int playcount, string thumbnail, string fanart, string poster) {
            update(setid, label, playcount, thumbnail, fanart, poster);
        }
        public MovieSetTableEntry(MovieSet movieset) {
            update(movieset);
        }
        public void update(MovieSet movieset) {
            update(movieset.SetId, movieset.Label, movieset.PlayCount, movieset.Thumbnail, movieset.Art.Fanart, movieset.Art.Poster);
        }
        public void update(int setid, string label, int playcount, string thumbnail, string fanart, string poster) {
            this.setid = setid;
            this.label = label;
            this.playcount = playcount;
            this.thumbnail = thumbnail;
            this.fanart = fanart;
            this.poster = poster;
        }
    }
}
