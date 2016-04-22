using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.KJSONRPC.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class JSONRPC {
        [Fact]
        public async Task GetConfiguration() {
            Configuration result = await ActiveKodi.Instance.JSONRPC.GetConfiguration();
            Assert.True(result.Notifications.Application);
        }
        [Fact]
        public async Task NotifyAll() {
            bool result = await ActiveKodi.Instance.JSONRPC.NotifyAll("sender", "message");
            Assert.True(result);
        }
        [Fact]
        public async Task Permission() {
            Permissions result = await ActiveKodi.Instance.JSONRPC.Permission();
            Assert.True(result.ControlGUI);
        }
        [Fact]
        public async Task Ping() {
            bool result = await ActiveKodi.Instance.JSONRPC.Ping();
            Assert.True(result);
        }
        [Fact]
        public async Task Version() {
            KodiRemote.Code.JSON.KJSONRPC.Results.Version result = await ActiveKodi.Instance.JSONRPC.Version();
            Assert.True(result.VersionValue.Major == 6);
        }
        [Fact]
        public async Task SetConfiguration() {
            Configuration result = await ActiveKodi.Instance.JSONRPC.SetConfiguration(false);
            Assert.False(result.Notifications.GUI);
            result = await ActiveKodi.Instance.JSONRPC.SetConfiguration(true);
            Assert.True(result.Notifications.GUI);
        }
    }
}
