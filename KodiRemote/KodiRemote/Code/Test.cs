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

            //results
            kodi.Application.GetPropertiesReceived += (JSON.KApplication.Results.ApplicationProperties item) => {
                Debug.WriteLine(item);
            };
            kodi.Application.QuitReceived += (bool b) => {
                Debug.WriteLine(b);
            };
            kodi.Application.SetMuteReceived += (bool b) => {
                Debug.WriteLine(b);
            };
            kodi.Application.SetVolumeReceived += (int b) => {
                Debug.WriteLine(b);
            };

            kodi.Application.GetProperties(JSON.Fields.ApplicationField.WithAll());
            kodi.Application.SetMute(ToggleEnum.True);
            await Task.Delay(2000);
            kodi.Application.SetMute(ToggleEnum.False);
            await Task.Delay(2000);
            kodi.Application.SetMute(ToggleEnum.Toggle);
            await Task.Delay(2000);
            kodi.Application.SetVolume(IncDecEnum.Decrement);
            await Task.Delay(2000);
            kodi.Application.SetVolume(IncDecEnum.Increment);
            await Task.Delay(2000);
            kodi.Application.SetVolume(0);
            await Task.Delay(2000);
            kodi.Application.SetVolume(50);
            await Task.Delay(2000);
            kodi.Application.SetVolume(100);
            await Task.Delay(2000);
            kodi.Application.Quit();
        }
    }
}
