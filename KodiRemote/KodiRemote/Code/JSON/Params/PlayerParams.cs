using KodiRemote.Code.JSON.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Params {

    [DataContract]
    public class ActivePlayerParams {
        public ActivePlayerParams() { }
        public ActivePlayerParams(int playerId, IField properties) {
            PlayerId = playerId;
            Properties = properties.ToList();
        }
        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
        [DataMember(Name = "properties")]
        public List<string> Properties { get; set; }
    }
}
