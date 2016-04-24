using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.KJSONRPC.Results;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.KodiRPC {
    [Collection("Kodi")]
    public class JSONRPC {
        [Fact]
        public async Task GetConfiguration() {
            Configuration result = await Kodi.ActiveInstance.JSONRPC.GetConfiguration();
            Assert.True(result.Notifications.Application);
        }
        [Fact]
        public async Task NotifyAll() {
            bool result = await Kodi.ActiveInstance.JSONRPC.NotifyAll("sender", "message");
            Assert.True(result);
        }
        [Fact]
        public async Task Permission() {
            Permissions result = await Kodi.ActiveInstance.JSONRPC.Permission();
            Assert.True(result.ControlGUI);
        }
        [Fact]
        public async Task Ping() {
            bool result = await Kodi.ActiveInstance.JSONRPC.Ping();
            Assert.True(result);
        }
        [Fact]
        public async Task Version() {
            KodiRemote.Code.JSON.KJSONRPC.Results.Version result = await Kodi.ActiveInstance.JSONRPC.Version();
            Assert.True(result.VersionValue.Major == 6);
        }
        [Fact]
        public async Task SetConfiguration() {
            Configuration result = await Kodi.ActiveInstance.JSONRPC.SetConfiguration(false);
            Assert.False(result.Notifications.GUI);
            result = await Kodi.ActiveInstance.JSONRPC.SetConfiguration(true);
            Assert.True(result.Notifications.GUI);
        }
    }
}
