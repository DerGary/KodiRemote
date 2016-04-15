using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class Time {
        public Time(int hours, int minutes, int seconds, int milliseconds = 0) {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Milliseconds = milliseconds;
        }
        [DataMember(Name = "hours")]
        public int Hours { get; set; }
        [DataMember(Name = "milliseconds")]
        public int Milliseconds { get; set; }
        [DataMember(Name = "minutes")]
        public int Minutes { get; set; }
        [DataMember(Name = "seconds")]
        public int Seconds { get; set; }
    }
}
