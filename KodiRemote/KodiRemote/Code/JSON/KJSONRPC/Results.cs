using KodiRemote.Code.JSON.KFiles.Params;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KJSONRPC.Results {

    [DataContract]
    public class Permissions {
        [DataMember(Name = "ControlGUI")]
        public bool ControlGUI { get; set; }
        [DataMember(Name = "ControlNotify")]
        public bool ControlNotify { get; set; }
        [DataMember(Name = "ControlPVR")]
        public bool ControlPVR { get; set; }
        [DataMember(Name = "ControlPlayback")]
        public bool ControlPlayback { get; set; }
        [DataMember(Name = "ControlPower")]
        public bool ControlPower { get; set; }
        [DataMember(Name = "ControlSystem")]
        public bool ControlSystem { get; set; }
        [DataMember(Name = "ExecuteAddon")]
        public bool ExecuteAddon { get; set; }
        [DataMember(Name = "ManageAddon")]
        public bool ManageAddon { get; set; }
        [DataMember(Name = "Navigate")]
        public bool Navigate { get; set; }
        [DataMember(Name = "ReadData")]
        public bool ReadData { get; set; }
        [DataMember(Name = "RemoveData")]
        public bool RemoveData { get; set; }
        [DataMember(Name = "UpdateData")]
        public bool UpdateData { get; set; }
        [DataMember(Name = "WriteFile")]
        public bool WriteFile { get; set; }
    }
    [DataContract]
    public class JSONRPCVersion {

        [DataMember(Name = "version")]
        public APIVersion VersionValue { get; set; }
    }

    [DataContract]
    public class APIVersion {
        [DataMember(Name = "major")]
        public int Major { get; set; }
        [DataMember(Name = "minor")]
        public int Minor { get; set; }
        [DataMember(Name = "patch")]
        public int Patch { get; set; }
    }
    [DataContract]
    public class Configuration : SetConfiguration {
    }
}
