using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public interface IField {
        void All();
        List<string> ToList();
    }
}
