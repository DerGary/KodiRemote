using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class AddonField : IField {
        public bool Name { get; set; }
        public bool Version { get; set; }
        public bool Summary { get; set; }
        public bool Description { get; set; }
        public bool Path { get; set; }
        public bool Author { get; set; }
        public bool Thumbnail { get; set; }
        public bool Disclaimer { get; set; }
        public bool Fanart { get; set; }
        public bool Dependencies { get; set; }
        public bool Broken { get; set; }
        public bool Extrainfo { get; set; }
        public bool Rating { get; set; }
        public bool Enabled { get; set; }
        public void All() {
            Name = true;
            Version = true;
            Summary = true;
            Description = true;
            Path = true;
            Author = true;
            Thumbnail = true;
            Disclaimer = true;
            Fanart = true;
            Dependencies = true;
            Broken = true;
            Extrainfo = true;
            Rating = true;
            Enabled = true;
        }
        public List<String> ToList() {
            List<string> list = new List<string>();
            if (Name)
                list.Add("name");
            if (Version)
                list.Add("version");
            if (Summary)
                list.Add("summary");
            if (Description)
                list.Add("description");
            if (Path)
                list.Add("path");
            if (Author)
                list.Add("author");
            if (Thumbnail)
                list.Add("thumbnail");
            if (Disclaimer)
                list.Add("disclaimer");
            if (Fanart)
                list.Add("fanart");
            if (Dependencies)
                list.Add("dependencies");
            if (Broken)
                list.Add("broken");
            if (Extrainfo)
                list.Add("extrainfo");
            if (Rating)
                list.Add("rating");
            if (Enabled)
                list.Add("enabled");
            return list;
        }
    }
}
