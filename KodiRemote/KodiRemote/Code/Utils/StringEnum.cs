using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Utils {
    public abstract class StringEnum {
        protected readonly string name;
        protected readonly int value;

        protected StringEnum(int value, string name) {
            this.name = name;
            this.value = value;
        }
        public override string ToString() {
            return name;
        }

        public int ToInt() {
            return value;
        }

        static public implicit operator string(StringEnum method) {
            return method.ToString();
        }

        static public implicit operator int(StringEnum method) {
            return method.value;
        }
    }
}
