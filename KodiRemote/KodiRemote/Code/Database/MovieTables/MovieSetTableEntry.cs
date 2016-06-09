using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.JSON.KVideoLibrary.Results;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MovieTables {

    [Table("MovieSets")]
    public class MovieSetTableEntry : TableEntryWithLabelBase {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SetId { get; set; }
        public int PlayCount { get; set; }
        public string Thumbnail { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return SetId.ToString();
            }
        }

        public List<MovieMovieSetMapper> Movies { get; set; }

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
            this.SetId = setid;
            this.Label = label;
            this.PlayCount = playcount;
            this.Thumbnail = thumbnail;
            this.Fanart = fanart;
            this.Poster = poster;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as MovieSetTableEntry);
        }
        public bool Equals(MovieSetTableEntry obj) {
            if((object) obj == null) {
                return false;
            }

            return IsKeyEqual(obj)
                && Label == obj.Label
                && PlayCount == obj.PlayCount
                && Thumbnail == obj.Thumbnail
                && Fanart == obj.Fanart
                && Poster == obj.Poster;
        }

        public override bool IsKeyEqual(TableEntryBase other) {
            var obj = other as MovieSetTableEntry;
            return SetId == obj?.SetId;
        }

        public override int GetHashCode() {
            return SetId;
        }
    }
}
