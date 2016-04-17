using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAddons.Params {
    [DataContract]
    public class AddonID {
        [DataMember(Name = "addonid")]
        public string AddonId { get; set; }
    }

    [DataContract]
    public class ExecuteAddon : AddonID {
        [DataMember(Name = "params", EmitDefaultValue = false)]
        public List<string> Params { get; set; }
        [DataMember(Name = "wait")]
        public bool Wait { get; set; }
    }
    [DataContract]
    public class GetAddonDetails : AddonID {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }
    [DataContract]
    public class GetAddons {
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }
        [DataMember(Name = "enabled", EmitDefaultValue = false)]
        public bool? Enabled { get; set; }
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
    }
    [DataContract]
    public class SetAddonEnabled<T> : AddonID {
        [DataMember(Name = "enabled")]
        public T Enabled { get; set; }
    }

}
