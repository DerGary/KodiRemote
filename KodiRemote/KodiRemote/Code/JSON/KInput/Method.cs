using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KInput {
    public sealed class Method : StringEnum {
        public static readonly Method SendText = new Method(101, "SendText");
        public static readonly Method Home = new Method(102, "Home");
        public static readonly Method ExecuteAction = new Method(103, "ExecuteAction");
        public static readonly Method ShowCodec = new Method(104, "ShowCodec");
        public static readonly Method ShowOSD = new Method(105, "ShowOSD");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Input." + name;
        }
    }
}
