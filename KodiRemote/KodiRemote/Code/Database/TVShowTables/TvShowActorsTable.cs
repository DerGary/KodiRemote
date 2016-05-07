using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.TVShowTables {

    [Table("TVShowActors")]
    public class TVShowActorsTableEntry {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TVShowId { get; set; }
        public int ActorId { get; set; }
        public string Role { get; set; }

        public TVShowActorsTableEntry() { }
        public TVShowActorsTableEntry(TVShow tvshow, ActorsTableEntry actorEntry, Actor actor) : this() {
            TVShowId = tvshow.TVShowId;
            Role = actor.Role;
            ActorId = actorEntry.ActorId;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            TVShowActorsTableEntry other = obj as TVShowActorsTableEntry;
            if ((System.Object)other == null) {
                return false;
            }

            return TVShowId == other.TVShowId && ActorId == other.ActorId && Role == other.Role;
        }

        public bool Equals(TVShowActorsTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return TVShowId == other.TVShowId && ActorId == other.ActorId && Role == other.Role;
        }

        public override int GetHashCode() {
            return TVShowId.GetHashCode() ^ ActorId.GetHashCode() ^ Role.GetHashCode();
        }
    }
}
