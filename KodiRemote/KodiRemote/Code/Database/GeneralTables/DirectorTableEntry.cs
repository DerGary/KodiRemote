
using KodiRemote.Code.Database.EpisodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("Directors")]
    public class DirectorTableEntry {
        [Key]
        public int DirectorId { get; set; }
        public string Name { get; set; }

        public List<EpisodeDirectorMapper> Episodes { get; set; }

        public DirectorTableEntry() { }
        public DirectorTableEntry(string director) {
            Name = director;
        }
    }
}
