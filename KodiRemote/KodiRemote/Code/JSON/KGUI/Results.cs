using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KGUI.Results {
    [DataContract]
    public class GUIProperties {
        [DataMember(Name = "currentcontrol")]
        public CurrentControl CurrentControl { get; set; }
        [DataMember(Name = "currentwindow")]
        public CurrentWindow CurrentWindow { get; set; }
        [DataMember(Name = "skin")]
        public Skin Skin { get; set; }
        [DataMember(Name = "fullscreen")]
        public bool Fullscreen { get; set; }
    }
    [DataContract]
    public class CurrentControl {
        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
    [DataContract]
    public class CurrentWindow {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
    [DataContract]
    public class Skin {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
