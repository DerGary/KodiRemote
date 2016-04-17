using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KGUI.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IGUIService {
        event ReceivedEventHandler<bool> ActivateWindowReceived;
        event ReceivedEventHandler<GUIProperties> GetPropertiesReceived;
        event ReceivedEventHandler<bool> SetFullscreenReceived;
        event ReceivedEventHandler<bool> ShowNotificationReceived;
        void ActivateWindow(WindowEnum window, List<string> parameters = null);
        void GetProperties(GUIField properties);
        void SetFullscreen(ToggleEnum fullscreen);
        void ShowNotification(string title, string message, ImageEnum image, int displaytime = 0);
    }
}
