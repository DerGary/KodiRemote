using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using System;
using Xunit;

namespace UnitTestProject2 {
    public class UnitTest1 {

        ActiveKodi Kodi;

        public UnitTest1() {
            ActiveKodi.Init("openelec", "9090", ConnectionType.Websocket);
            Kodi = ActiveKodi.Instance;
        }

        [Fact]
        public void MyFirstTheory() {
            Kodi.Application.SetMuteReceived += (bool b) => {
                Assert.True(b);
            };
            Kodi.Application.SetMute(ToggleEnum.Toggle);
        }
    }
}
