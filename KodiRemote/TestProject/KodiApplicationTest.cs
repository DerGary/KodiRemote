using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

using System.Threading.Tasks;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KApplication.Results;

namespace TestProject {
    //[TestClass]
    //public class KodiApplicationTest {

    //    [ClassInitialize]
    //    public static async Task Init(TestContext context) {
    //        await ActiveKodi.Init("localhost", "9090", ConnectionType.Websocket);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationGetProperties() {
    //        ApplicationProperties result = await ActiveKodi.Instance.Application.GetProperties(ApplicationField.WithAll());
    //        Assert.IsTrue(result.Volume == 100);
    //        Assert.IsTrue(result.Version.major == 16);
    //        Assert.IsTrue(result.Version.minor == 0);
    //        Assert.IsTrue(result.Version.revision == "20160220-a5f3a99");
    //        Assert.IsTrue(result.Version.tag == "stable");
    //        Assert.IsTrue(result.Name == "Kodi");
    //        Assert.IsTrue(result.Muted == false);
    //    }

    //    [TestMethod]
    //    public async Task ApplicationSetMuteToTrue() {
    //        bool result = await ActiveKodi.Instance.Application.SetMute(ToggleEnum.True);
    //        Assert.IsTrue(result);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetMuteToFalse() {
    //        bool result = await ActiveKodi.Instance.Application.SetMute(ToggleEnum.False);
    //        Assert.IsFalse(result);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetMuteToToggle() {
    //        bool result = await ActiveKodi.Instance.Application.SetMute(ToggleEnum.True);
    //        result = await ActiveKodi.Instance.Application.SetMute(ToggleEnum.Toggle);
    //        Assert.IsFalse(result);
    //    }

    //    [TestMethod]
    //    public async Task ApplicationSetVolumeDecrement() {
    //        int result = await ActiveKodi.Instance.Application.SetVolume(IncDecEnum.Decrement);
    //        Assert.IsTrue(result > 95 && result < 100);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetVolumeIncrement() {
    //        int result = await ActiveKodi.Instance.Application.SetVolume(IncDecEnum.Increment);
    //        Assert.IsTrue(result == 100);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetVolumeTo1() {
    //        int result = await ActiveKodi.Instance.Application.SetVolume(1);
    //        Assert.IsTrue(result == 1);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetVolumeTo50() {
    //        int result = await ActiveKodi.Instance.Application.SetVolume(50);
    //        Assert.IsTrue(result == 50);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationSetVolumeTo100() {
    //        int result = await ActiveKodi.Instance.Application.SetVolume(100);
    //        Assert.IsTrue(result == 100);
    //    }
    //    [TestMethod]
    //    public async Task ApplicationQuit() {
    //        bool result = await ActiveKodi.Instance.Application.Quit();
    //        Assert.IsTrue(result);
    //    }
    //}
}
