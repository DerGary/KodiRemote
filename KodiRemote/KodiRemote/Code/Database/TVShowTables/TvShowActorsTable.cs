using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowActors")]
    public class TVShowActorsTableEntry {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Role { get; set; }


        [ForeignKey("TVShow")]
        public int TVShowId { get; set; }
        public TVShowTableEntry TVShow { get; set; }

        public TVShowActorsTableEntry() { }
        public TVShowActorsTableEntry(TVShow tvshow, Actor actor) : this() {
            TVShowId = tvshow.TVShowId;
            Role = actor.Role;
            Name = actor.Name;
            Thumbnail = actor.Thumbnail;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowActorsTableEntry other = obj as TVShowActorsTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return TVShowId == other.TVShowId && Name == other.Name && Thumbnail == other.Thumbnail && Role == other.Role;
        }

        public bool Equals(TVShowActorsTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && Name == other.Name && Thumbnail == other.Thumbnail && Role == other.Role;
        }

        public override int GetHashCode() {
            return TVShowId.GetHashCode() ^ Name.GetHashCode() ^ Role.GetHashCode();
        }
    }
}
