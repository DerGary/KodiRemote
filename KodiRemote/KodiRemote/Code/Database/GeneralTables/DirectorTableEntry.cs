
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Directors")]
    public class DirectorTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DirectorId { get; set; }
        public string Name { get; set; }

        public List<EpisodeDirectorMapper> Episodes { get; set; }
        public List<MovieDirectorMapper> Movies { get; set; }
        public List<MusicVideoDirectorMapper> MusicVideos { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return Name;
            }
        }

        public DirectorTableEntry() { }
        public DirectorTableEntry(string director) {
            Name = director;
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as DirectorTableEntry);
        }

        public bool Equals(DirectorTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return this.Name == other.Name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }
        
    }
}
