using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON {
    public delegate void ReceivedEventHandler<T>(T item);
    public delegate void ReceivedEventHandler();
    public delegate void KodiChangedEventHandler(object sender, EventArgs e);
}
