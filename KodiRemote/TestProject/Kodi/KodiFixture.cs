using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    public class KodiFixture {
        public KodiFixture() {
            ActiveKodi.Init("localhost", "9090", ConnectionType.Websocket).Wait();
        }
    }

    [CollectionDefinition("Kodi")]
    public class KodiCollection : ICollectionFixture<KodiFixture> {

    }
}
