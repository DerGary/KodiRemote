using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code {
    public static class Test {

        public static async void StartTest() {
            //string hostname = "localhost";
            //string port = "9090";
            //await ActiveKodi.Init(hostname, port, ConnectionType.Websocket);
            ActiveKodi kodi = ActiveKodi.Instance;

            await ApplicationTest(kodi);

        }
        public static async Task ApplicationTest(ActiveKodi kodi) {
            //Notifications
            kodi.Application.OnVolumeChanged += (JSON.KApplication.Notifications.Data item) => {
                Debug.WriteLine(item);
            };


            var props = await kodi.Application.GetProperties(JSON.Fields.ApplicationField.WithAll());
            Debug.WriteLine(props);
            var mute = await kodi.Application.SetMute(ToggleEnum.True);
            mute = await kodi.Application.SetMute(ToggleEnum.False);
            mute = await kodi.Application.SetMute(ToggleEnum.Toggle);
            var volume = await kodi.Application.SetVolume(IncDecEnum.Decrement);
            volume = await kodi.Application.SetVolume(IncDecEnum.Increment);
            volume = await kodi.Application.SetVolume(0);
            volume = await kodi.Application.SetVolume(50);
            volume = await kodi.Application.SetVolume(100);
            var quit = await kodi.Application.Quit();
        }
    }
}
