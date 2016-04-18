using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KFiles {
    public sealed class Method : StringEnum {
        public static readonly Method Download = new Method(501, "Download");
        public static readonly Method GetDirectory = new Method(502, "GetDirectory");
        public static readonly Method GetFileDetails = new Method(503, "GetFileDetails");
        public static readonly Method GetSources = new Method(504, "GetSources");
        public static readonly Method PrepareDownload = new Method(505, "PrepareDownload");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Files." + name;
        }
    }
}
