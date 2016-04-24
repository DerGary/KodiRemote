using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.KodiRPC {
    public class KodiFixture {
        public KodiFixture() {
            Kodi.Init(new KodiSettings("localhost", "9090", ConnectionType.Websocket)).Wait();
        }
    }

    [CollectionDefinition("Kodi")]
    public class KodiCollection : ICollectionFixture<KodiFixture> {

    }
}
