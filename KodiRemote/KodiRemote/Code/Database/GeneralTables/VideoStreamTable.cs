﻿
using KodiRemote.Code.Database.EpisodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("VideoStreams")]
    public class VideoStreamTableEntry {
        [Key]
        public int VideoStreamId { get; set; }
        public string Codec { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float Aspect { get; set; }

        public List<EpisodeVideoStreamMapper> Episodes { get; set; }
    }
}
