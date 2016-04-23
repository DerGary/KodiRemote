using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KSystem.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class System {
        [Fact]
        public async Task EjectOpticalDrive() {
            bool result = await ActiveKodi.Instance.System.EjectOpticalDrive();
            Assert.True(result);
        }
        [Fact]
        public async Task GetProperties() {
            SystemProperties result = await ActiveKodi.Instance.System.GetProperties(SystemField.WithAll());
            Assert.True(result.CanShutdown);
        }
        [Fact]
        public async Task Hibernate() {
            bool result = await ActiveKodi.Instance.System.Hibernate();
            Assert.True(result);
        }
        [Fact]
        public async Task Reboot() {
            bool result = await ActiveKodi.Instance.System.Reboot();
            Assert.True(result);
        }
        [Fact]
        public async Task Shutdown() {
            bool result = await ActiveKodi.Instance.System.Shutdown();
            Assert.True(result);
        }
        [Fact]
        public async Task Suspend() {
            bool result = await ActiveKodi.Instance.System.Suspend();
            Assert.True(result);
        }
    }
}
