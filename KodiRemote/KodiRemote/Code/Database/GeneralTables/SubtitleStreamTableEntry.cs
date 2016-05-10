
using KodiRemote.Code.Database.EpisodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("SubtitleStreams")]
    public class SubtitleStreamTableEntry {
        [Key]
        public int SubtitleStreamId { get; set; }
        public string Language { get; set; }

        public List<EpisodeSubtitleStreamMapper> Episodes { get; set; }
    }
}
