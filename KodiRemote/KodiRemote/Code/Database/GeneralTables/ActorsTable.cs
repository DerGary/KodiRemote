using KodiRemote.Code.JSON.General;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Actors")]
    public class ActorsTableEntry {
        [PrimaryKey, AutoIncrement]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public ActorsTableEntry() { }
        public ActorsTableEntry(Actor actor) : this() {
            Name = actor.Name;
            Thumbnail = actor.Thumbnail;
        }
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            ActorsTableEntry other = obj as ActorsTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return Name == other.Name && Thumbnail == other.Thumbnail;
        }

        public bool Equals(ActorsTableEntry other) {
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
