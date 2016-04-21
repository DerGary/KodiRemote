using System;

using System.Threading.Tasks;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KApplication.Results;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class Application {
        [Fact]
        public async Task GetProperties() {
            await SetMute(false);
            await SetVolume(100);
            ApplicationProperties result = await ActiveKodi.Instance.Application.GetProperties(ApplicationField.WithAll());
            Assert.True(result.Volume == 100);
            Assert.True(result.Version.major == 16);
            Assert.True(result.Version.minor == 0);
            Assert.True(result.Version.revision == "20160220-a5f3a99");
            Assert.True(result.Version.tag == "stable");
            Assert.True(result.Name == "Kodi");
            Assert.True(result.Muted == false);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task SetMute(bool b) {
            bool result = await ActiveKodi.Instance.Application.SetMute(b == true ? ToggleEnum.True : ToggleEnum.False);
            Assert.True(result == b);
        }

        [Fact]
        public async Task SetMuteToToggle() {
            await SetMute(true);
            bool result = await ActiveKodi.Instance.Application.SetMute(ToggleEnum.Toggle);
            Assert.False(result);
        }

        [Fact]
        public async Task SetVolumeDecrement() {
            int result = await ActiveKodi.Instance.Application.SetVolume(IncDecEnum.Decrement);
            Assert.True(result > 95 && result < 100);
        }
        [Fact]
        public async Task SetVolumeIncrement() {
            int result = await ActiveKodi.Instance.Application.SetVolume(IncDecEnum.Increment);
            Assert.True(result == 100);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        public async Task SetVolume(int volume) {
            int result = await ActiveKodi.Instance.Application.SetVolume(volume);
            Assert.True(result == volume);
        }
        //[Fact]
        //public async Task Quit() {
        //    bool result = await ActiveKodi.Instance.Application.Quit();
        //    Assert.True(result);
        //}
    }
}
