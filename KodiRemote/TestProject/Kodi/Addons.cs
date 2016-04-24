using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KAddons.Results;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class Addons {
        [Theory]
        [InlineData(1, 1, null, null, null)]
        [InlineData(2, 1, null, null, null)]
        [InlineData(3, 1, null, null, null)]
        [InlineData(4, 1, null, null, null)]
        [InlineData(5, 1, null, null, null)]
        [InlineData(6, 1, null, null, null)]
        [InlineData(1, 2, true, null, 5)]
        [InlineData(1, 3, true, null, 5)]
        [InlineData(1, 1, true, "kodi.audiodecoder", 5)]
        public async Task GetAddons(int content, int enabled, bool? properties, string type, int? limit) {
            AddonsResult result = await ActiveKodi.Instance.Addons.GetAddons(
                ContentEnum.FromInt(content),
                EnabledEnum.FromInt(enabled),
                properties == true ? AddonField.WithAll() : null,
                type,
                limit != null ? new Limits(0, (int)limit) : null);

            Assert.True(result.Addons.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);//Limits.Total is sometimes more than Addons.Count
            if (limit != null) {
                Assert.True(result.Addons.Count == limit);
            }
            Assert.True(!string.IsNullOrEmpty(result.Addons.First().AddonId));
            Assert.True(!string.IsNullOrEmpty(result.Addons.First().Type));
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task ExecuteAddon(bool wait) {
            bool result = await ActiveKodi.Instance.Addons.ExecuteAddon("screensaver.stars",wait: wait );
            Assert.True(result);
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetAddonDetails(bool properties) {
            AddonResult result = await ActiveKodi.Instance.Addons.GetAddonDetails("screensaver.stars", properties ? AddonField.WithAll() : null);
            Assert.True(result.Addon.AddonId == "screensaver.stars");
        }
        [Theory]
        //[InlineData(false)] False and Toggle do not work
        [InlineData(true)]
        public async Task SetAddonEnabled(bool enabled) {
            bool result = await ActiveKodi.Instance.Addons.SetAddonEnabled("screensaver.stars", enabled ? ToggleEnum.True : ToggleEnum.False);
            Assert.True(result);
        }
        //[Fact]
        //public async Task SetAddonEnabledToToggle() {
        //    bool result = await ActiveKodi.Instance.Addons.SetAddonEnabled("screensaver.stars", ToggleEnum.Toggle);
        //    Assert.True(result);
        //}
    }
}
