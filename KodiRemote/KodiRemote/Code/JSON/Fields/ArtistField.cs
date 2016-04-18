using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class ArtistField : IField {
        public bool Instrument { get; set; }
        public bool Style { get; set; }
        public bool Mood { get; set; }
        public bool Born { get; set; }
        public bool Formed { get; set; }
        public bool Description { get; set; }
        public bool Genre { get; set; }
        public bool Died { get; set; }
        public bool Disbanded { get; set; }
        public bool Yearsactive { get; set; }
        public bool Musicbrainzartistid { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public void All() {
            Instrument = true;
            Style = true;
            Mood = true;
            Born = true;
            Formed = true;
            Description = true;
            Genre = true;
            Died = true;
            Disbanded = true;
            Yearsactive = true;
            Musicbrainzartistid = true;
            Fanart = true;
            Thumbnail = true;
        }
        public List<String> ToList() {
            List<String> list = new List<string>();
            if (Instrument)
                list.Add("instrument");
            if (Style)
                list.Add("style");
            if (Mood)
                list.Add("mood");
            if (Born)
                list.Add("born");
            if (Formed)
                list.Add("formed");
            if (Description)
                list.Add("description");
            if (Genre)
                list.Add("genre");
            if (Died)
                list.Add("died");
            if (Disbanded)
                list.Add("disbanded");
            if (Yearsactive)
                list.Add("yearsactive");
            if (Musicbrainzartistid)
                list.Add("musicbrainzartistid");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            return list;
        }

        internal void Mine() {
            Born = true;
            Formed = true;
            Description = true;
            Died = true;
            Fanart = true;
            Thumbnail = true;
        }
    }
}
