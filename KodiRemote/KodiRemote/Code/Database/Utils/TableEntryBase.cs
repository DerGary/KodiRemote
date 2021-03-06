﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.Utils {
    public abstract class TableEntryBase : IKeyComparable<TableEntryBase> {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public virtual bool IsKeyEqual(TableEntryBase other) {
            return this.Equals(other);
        }
        public abstract string Key { get; }
    }
    public abstract class TableEntryWithLabelBase: TableEntryBase {
        public string Label { get; set; }
    }
    public abstract class TableEntryWithLabelAndRatingBase : TableEntryWithLabelBase {
        public float Rating { get; set; }
    }
    public abstract class MovieTVShowTableEntryBase : TableEntryWithLabelAndRatingBase {
        public string Poster { get; set; }
        public string Fanart { get; set; }
        public string Plot { get; set; }
        public string IMDBNumber { get; set; }
        public string DateAdded { get; set; }
    }
}
