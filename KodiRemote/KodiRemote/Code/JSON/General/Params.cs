using KodiRemote.Code.JSON.General.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General.Params {
    #region Base
    [DataContract]
    public abstract class PropertyBase {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }

    [DataContract]
    public class LimitSortPropertyBase : PropertyBase {
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public Sort Sort { get; set; }
    }
    [DataContract]
    public class FilterLimitSortPropertyBase<T> : LimitSortPropertyBase where T : FilterBase {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public T Filter { get; set; }
    }
    [DataContract]
    public abstract class Options { }

    #endregion Base



    [DataContract]
    public class Export<T> where T : Options {
        [DataMember(Name = "options")]
        public T Options { get; set; }
    }

    [DataContract]
    public class PathOption : Options {
        [DataMember(Name = "path", EmitDefaultValue = false)]
        public string Path { get; set; }
    }
}
