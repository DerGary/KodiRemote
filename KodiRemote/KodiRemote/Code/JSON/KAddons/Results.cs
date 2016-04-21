using KodiRemote.Code.JSON.General.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAddons.Results {
    [DataContract]
    public class AddonsResult : CollectionResultBase {
        [DataMember(Name = "addons")]
        public List<Addon> Addons { get; set; }
    }
    [DataContract]
    public class AddonResult {
        [DataMember(Name = "addon")]
        public Addon Addon { get; set; }
    }
    [DataContract]
    public class Addon {
        [DataMember(Name = "addonid")]
        public string AddonId { get; set; }
        [DataMember(Name = "author")]
        public string Author { get; set; }
        [DataMember(Name = "broken")]
        public bool Broken { get; set; }
        [DataMember(Name = "dependencies")]
        public Dependency[] Dependencies { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "disclaimer")]
        public string Disclaimer { get; set; }
        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "extrainfo")]
        public ExtraInfo[] ExtraInfo { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "path")]
        public string Path { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
    [DataContract]
    public class Dependency {
        [DataMember(Name = "addonid")]
        public string AddonId { get; set; }
        [DataMember(Name = "optional")]
        public bool Optional { get; set; }
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
    [DataContract]
    public class ExtraInfo {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}