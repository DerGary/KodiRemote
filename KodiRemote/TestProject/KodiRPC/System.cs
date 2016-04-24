using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KSystem.Results;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.KodiRPC {
    [Collection("Kodi")]
    public class System {
        [Fact]
        public async Task EjectOpticalDrive() {
            bool result = await Kodi.ActiveInstance.System.EjectOpticalDrive();
            Assert.True(result);
        }
        [Fact]
        public async Task GetProperties() {
            SystemProperties result = await Kodi.ActiveInstance.System.GetProperties(SystemField.WithAll());
            Assert.True(result.CanShutdown);
        }
        [Fact]
        public async Task Hibernate() {
            bool result = await Kodi.ActiveInstance.System.Hibernate();
            Assert.True(result);
        }
        [Fact]
        public async Task Reboot() {
            bool result = await Kodi.ActiveInstance.System.Reboot();
            Assert.True(result);
        }
        [Fact]
        public async Task Shutdown() {
            bool result = await Kodi.ActiveInstance.System.Shutdown();
            Assert.True(result);
        }
        [Fact]
        public async Task Suspend() {
            bool result = await Kodi.ActiveInstance.System.Suspend();
            Assert.True(result);
        }
    }
}
