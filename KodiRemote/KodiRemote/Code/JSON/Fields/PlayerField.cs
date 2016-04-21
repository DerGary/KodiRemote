using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class PlayerField : Field<PlayerField> {
        public bool Type { get; set; }
        public bool Partymode { get; set; }
        public bool Speed { get; set; }
        public bool Time { get; set; }
        public bool Percentage { get; set; }
        public bool Totaltime { get; set; }
        public bool Playlistid { get; set; }
        public bool Position { get; set; }
        public bool Repeat { get; set; }
        public bool Shuffled { get; set; }
        public bool Canseek { get; set; }
        public bool Canchangespeed { get; set; }
        public bool Canmove { get; set; }
        public bool Canzoom { get; set; }
        public bool Canrotate { get; set; }
        public bool Canshuffle { get; set; }
        public bool Canrepeat { get; set; }
        public bool Currentaudiostream { get; set; }
        public bool Audiostreams { get; set; }
        public bool Subtitleenabled { get; set; }
        public bool Currentsubtitle { get; set; }
        public bool Subtitles { get; set; }
        public bool Live { get; set; }
        public override void All() {
            Type = true;
            Partymode = true;
            Speed = true;
            Time = true;
            Percentage = true;
            Totaltime = true;
            Playlistid = true;
            Position = true;
            Repeat = true;
            Shuffled = true;
            Canseek = true;
            Canchangespeed = true;
            Canmove = true;
            Canzoom = true;
            Canrotate = true;
            Canshuffle = true;
            Canrepeat = true;
            Currentaudiostream = true;
            Audiostreams = true;
            Subtitleenabled = true;
            Currentsubtitle = true;
            Subtitles = true;
            Live = true;
        }
        public override List<string> ToList() {
            List<string> list = new List<string>();
            if (Type)
                list.Add("type");
            if (Partymode)
                list.Add("partymode");
            if (Speed)
                list.Add("speed");
            if (Time)
                list.Add("time");
            if (Percentage)
                list.Add("percentage");
            if (Totaltime)
                list.Add("totaltime");
            if (Playlistid)
                list.Add("playlistid");
            if (Position)
                list.Add("position");
            if (Repeat)
                list.Add("repeat");
            if (Shuffled)
                list.Add("shuffled");
            if (Canseek)
                list.Add("canseek");
            if (Canchangespeed)
                list.Add("canchangespeed");
            if (Canmove)
                list.Add("canmove");
            if (Canzoom)
                list.Add("canzoom");
            if (Canrotate)
                list.Add("canrotate");
            if (Canshuffle)
                list.Add("canshuffle");
            if (Canrepeat)
                list.Add("canrepeat");
            if (Currentaudiostream)
                list.Add("currentaudiostream");
            if (Audiostreams)
                list.Add("audiostreams");
            if (Subtitleenabled)
                list.Add("subtitleenabled");
            if (Currentsubtitle)
                list.Add("currentsubtitle");
            if (Subtitles)
                list.Add("subtitles");
            if (Live)
                list.Add("live");
            return list;
        }
    }
}
