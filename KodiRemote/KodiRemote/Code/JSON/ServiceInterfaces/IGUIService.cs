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
        Task<bool> ActivateWindow(WindowEnum window, List<string> parameters = null);
        Task<GUIProperties> GetProperties(GUIField properties);
        Task<bool> SetFullscreen(ToggleEnum fullscreen);
        Task<bool> ShowNotification(string title, string message, ImageEnum image, int displaytime = 0);
    }
}
