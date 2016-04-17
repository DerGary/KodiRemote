﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class ApplicationField : IField {
        public bool Volume { get; set; }
        public bool Muted { get; set; }
        public bool Name { get; set; }
        public bool Version { get; set; }
        public void All() {
            Volume = true;
            Muted = true;
            Name = true;
            Version = true;
        }
        public List<string> ToList() {
            List<string> list = new List<string>();
            if (Volume)
                list.Add("volume");
            if (Muted)
                list.Add("muted");
            if (Name)
                list.Add("name");
            if (Version)
                list.Add("version");
            return list;
        }
    }
}
