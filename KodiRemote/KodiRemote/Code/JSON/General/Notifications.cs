using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General.Notifications {
    [DataContract]
    public class Item {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        //type can be :
        //"unknown", 
        //"movie", 
        //"episode", 
        //"musicvideo", 
        //"song", 
        //"picture", 
        //"channel"

        [DataMember(Name = "id")]
        public int Id { get; set; }

        //Movie:
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }

        //Episode:
        [DataMember(Name = "showtitle")]
        public int ShowTitle { get; set; }
        [DataMember(Name = "episode")]
        public int Episode { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }

        //MusicVideo
        [DataMember(Name = "album")]
        public string Album { get; set; }
        [DataMember(Name = "artist")]
        public string Artist { get; set; }

        //Song
        [DataMember(Name = "track")]
        public string Track { get; set; }

        //Picture
        [DataMember(Name = "file")]
        public string FilePath { get; set; }

        //Channel

        [DataMember(Name = "channeltype")]
        public string ChannelType { get; set; }
        //type can be :
        //"tv", 
        //"radio"
    }
}
