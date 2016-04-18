using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General.Filter {
    [DataContract]
    public class FilterBase {
        [DataMember(Name = "genreid", EmitDefaultValue = false)]
        public int GenreId { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public string Genre { get; set; }
    }
}
