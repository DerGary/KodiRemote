using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.Utils {
    public interface IKeyComparable<T> where T : IKeyComparable<T> {
        bool IsKeyEqual(T other);
    }
}
