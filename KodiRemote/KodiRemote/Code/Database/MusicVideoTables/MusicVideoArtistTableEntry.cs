
using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.MusicVideoTables {

    [Table("MusicVideoArtists")]
    public class MusicVideoArtistTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MusicVideoArtistId { get; set; }
        public string Name { get; set; }

        public MusicVideoArtistTableEntry() { }
        public MusicVideoArtistTableEntry(string artist) {
            Name = artist;
        }

        [NotMapped]
        public override string Key {
            get {
                return Name;
            }
        }
        public List<MusicVideoArtistMapper> MusicVideos { get; set; }

        public override bool Equals(object obj) {
            return this.Equals(obj as MusicVideoArtistTableEntry);
        }

        public bool Equals(MusicVideoArtistTableEntry other) {
            return Name == other?.Name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }
    }
}
