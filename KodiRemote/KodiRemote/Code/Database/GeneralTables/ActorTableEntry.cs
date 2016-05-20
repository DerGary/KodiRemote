using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
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
    public class ActorTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }

        public List<TVShowActorMapper> TVShows { get; set; }
        public List<EpisodeActorMapper> Episodes { get; set; }
        public List<MovieActorMapper> Movies { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return Name + ";" + Thumbnail;
            }
        }

        public ActorTableEntry() { }
        public ActorTableEntry(Actor actor) : this() {
            Name = actor.Name;
            Thumbnail = actor.Thumbnail;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as ActorTableEntry);
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
