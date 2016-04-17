using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KSystem.Results {
    [DataContract]
    public class SystemProperties {
        [DataMember(Name = "canshutdown")]
        public bool CanShutdown { get; set; }
        [DataMember(Name = "canhibernate")]
        public bool CanHibernate { get; set; }
        [DataMember(Name = "cansuspend")]
        public bool CanSuspend { get; set; }
        [DataMember(Name = "canreboot")]
        public bool CanReboot { get; set; }
    }
}
