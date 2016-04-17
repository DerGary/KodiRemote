using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KGUI.Params {
    [DataContract]
    public class ActivateWindow {
        [DataMember(Name = "window")]
        public string Window { get; set; }
        [DataMember(Name = "parameters", EmitDefaultValue = false)]
        public List<string> Parameters { get; set; }
    }
    [DataContract]
    public class GetProperties {
        [DataMember(Name = "properties")]
        public List<string> Properties { get; set; }
    }
    [DataContract]
    public class SetFullScreen<T> {
        [DataMember(Name = "fullscreen")]
        public T Fullscreen { get; set; }
    }
    [DataContract]
    public class ShowNotification {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "image", EmitDefaultValue = false)]
        public string Image { get; set; }
        [DataMember(Name = "displaytime", EmitDefaultValue = false)]
        public int DisplayTime { get; set; }
    }
}
