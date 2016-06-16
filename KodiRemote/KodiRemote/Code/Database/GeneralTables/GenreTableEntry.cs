using KodiRemote.Code.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.GeneralTables {
    public class GenreTableEntry : TableEntryBase {
        [Key, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }
        [Required]
        public string Genre { get; set; }


        [NotMapped]
        public override string Key {
            get {
                return Genre;
            }
        }

        public override bool Equals(object obj) {
            return this.Equals(obj as GenreTableEntry);
        }

        public bool Equals(GenreTableEntry other) {
            // If parameter is null return false:
            if ((object)other == null) {
                return false;
            }

            // Return true if the fields match:
            return Genre == other.Genre;
        }

        public override int GetHashCode() {
            return Genre.GetHashCode();
        }
    }
}
