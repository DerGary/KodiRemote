﻿using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KPlayer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary.Notifications {
    [DataContract]
    public class Item {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
    [DataContract]
    public class UpdateItem : Item {
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
    }

}
