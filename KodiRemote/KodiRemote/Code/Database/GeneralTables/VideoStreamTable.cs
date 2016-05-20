
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
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

    [Table("VideoStreams")]
    public class VideoStreamTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VideoStreamId { get; set; }
        public string Codec { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float Aspect { get; set; }

        public List<EpisodeVideoStreamMapper> Episodes { get; set; }
        public List<MovieVideoStreamMapper> Movies { get; set; }

        [NotMapped]
        public override string Key {
            get {
                return Codec + ";" + Height + ";" + Width + ";" + Aspect;
            }
        }

        public VideoStreamTableEntry() { }
        public VideoStreamTableEntry(VideoStream stream) {
            Codec = stream.Codec;
            Height = stream.Height;
            Width = stream.Width;
            Aspect = stream.Aspect;
        }


        public override bool Equals(object obj) {
            return this.Equals(obj as VideoStreamTableEntry);
        }

        public bool Equals(VideoStreamTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return this.Codec == other.Codec && Height == other.Height && Width == other.Width && Aspect == other.Aspect;
        }

        public override int GetHashCode() {
            return Codec.GetHashCode() ^ Height.GetHashCode() ^ Width.GetHashCode();
        }
    }
}
