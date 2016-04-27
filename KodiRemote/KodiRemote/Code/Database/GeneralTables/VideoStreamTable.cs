using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {

    [Table("VideoStreams")]
    public class VideoStreamTableEntry {
        [PrimaryKey, AutoIncrement]
        public int videostreamid { get; set; }
        public string codec { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public float aspect { get; set; }
    }
}
