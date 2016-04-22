using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KGUI.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class GUI {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        //[InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        //[InlineData(14)]Kodi Exception
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        //[InlineData(22)]
        //[InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        //[InlineData(49)]Kodi unresponsive
        [InlineData(50)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(54)]
        //[InlineData(55)]Kodi Exception
        [InlineData(56)]
        [InlineData(57)]
        [InlineData(58)]
        [InlineData(59)]
        [InlineData(60)]
        [InlineData(61)]
        [InlineData(62)]
        [InlineData(63)]
        [InlineData(64)]
        [InlineData(65)]
        [InlineData(66)]
        [InlineData(67)]
        [InlineData(68)]
        [InlineData(69)]
        [InlineData(70)]
        [InlineData(71)]
        [InlineData(72)]
        [InlineData(73)]
        [InlineData(74)]
        [InlineData(75)]
        [InlineData(76)]
        [InlineData(77)]
        [InlineData(78)]
        [InlineData(79)]
        [InlineData(80)]
        [InlineData(81)]
        //[InlineData(82)]
        //[InlineData(83)]doesnt work
        [InlineData(84)]
        [InlineData(85)]
        [InlineData(86)]
        [InlineData(87)]
        [InlineData(88)]
        [InlineData(89)]
        [InlineData(90)]
        [InlineData(91)]
        [InlineData(92)]
        [InlineData(93)]
        [InlineData(94)]
        [InlineData(95)]
        [InlineData(96)]
        [InlineData(97)]
        [InlineData(98)]
        [InlineData(99)]
        //[InlineData(100)]
        //[InlineData(101)]
        [InlineData(102)]
        [InlineData(103)]
        [InlineData(104)]
        [InlineData(105)]
        [InlineData(106)]
        //[InlineData(107)]
        //[InlineData(108)]doesnt work
        [InlineData(109)]
        [InlineData(110)]
        //[InlineData(111)]doesnt work
        //[InlineData(112)]Exception in Kodi
        [InlineData(113)]
        [InlineData(114)]
        public async Task ActiveWindow(int window) {
            bool result = await ActiveKodi.Instance.GUI.ActivateWindow(WindowEnum.FromInt(window));
            Assert.True(result);
        }
        [Fact]
        public async Task ActiveWindowWithParam() {
            bool result = await ActiveKodi.Instance.GUI.ActivateWindow(WindowEnum.Video, new List<string>() { "movietitles" });
            Assert.True(result);
        }
        [Fact]
        public async Task GetProperties() {
            GUIProperties result = await ActiveKodi.Instance.GUI.GetProperties(GUIField.WithAll());
            Assert.True(!string.IsNullOrEmpty(result.Skin.Id));
        }
        //Doesnt work
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public async Task SetFullscreen(bool fullscreen) {
        //    bool result = await ActiveKodi.Instance.GUI.SetFullscreen(fullscreen ? ToggleEnum.True : ToggleEnum.False);
        //    Assert.True(result == fullscreen);
        //}
        //[Fact]
        //public async Task SetFullscreenToToggle() {
        //    //await SetFullscreen(true);
        //    bool result = await ActiveKodi.Instance.GUI.SetFullscreen(ToggleEnum.Toggle);
        //    Assert.False(result);
        //}
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(4, 1500)]
        [InlineData(4, 2154666)]
        public async Task ShowNotification(int image, int displaytime) {
            bool result = await ActiveKodi.Instance.GUI.ShowNotification("title","message", ImageEnum.FromInt(image), displaytime);
            Assert.True(result);
        }
    }
}
