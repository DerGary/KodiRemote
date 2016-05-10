using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.JSON.General;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Actors")]
    public class ActorTableEntry {
        [Key]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }

        public List<TVShowActorMapper> TVShows { get; set; }
        public List<EpisodeActorMapper> Episodes { get; set; }

        public ActorTableEntry() { }
        public ActorTableEntry(Actor actor) : this() {
            Name = actor.Name;
            Thumbnail = actor.Thumbnail;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            ActorTableEntry other = obj as ActorTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return Name == other.Name && Thumbnail == other.Thumbnail;
        }

        public bool Equals(ActorTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return Name == other.Name && Thumbnail == other.Thumbnail;
        }

        public override int GetHashCode() {
            return Name.GetHashCode() ^ Thumbnail.GetHashCode();
        }
    }
}
