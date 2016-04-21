using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KGUI.Results;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KGUI;
using KodiRemote.Code.JSON.KGUI.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class GUIWebSocketService : WebSocketServiceBase, IGUIService {
        public GUIWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.ActivateWindow.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetProperties.ToInt()) {
                DeserializeMessageAndTriggerTask<GUIProperties>(guid, message);
            } else if (methods[guid] == Method.SetFullscreen.ToInt()) {
                DeserializeMessageAndTriggerTask<bool>(guid, message);
            } else if (methods[guid] == Method.ShowNotification.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //nothing to do here :D
        }

        public Task<bool> ActivateWindow(WindowEnum window, List<string> parameters = null) {
            return SendRequest<bool, ActivateWindow>(Method.ActivateWindow, new ActivateWindow() { Window = window, Parameters = parameters });
        }

        public Task<GUIProperties> GetProperties(GUIField properties) {
            return SendRequest<GUIProperties, GetProperties>(Method.GetProperties, new GetProperties() { Properties = properties.ToList() });
        }

        public Task<bool> SetFullscreen(ToggleEnum fullscreen) {
            if (fullscreen == ToggleEnum.Toggle) {
                return SendRequest<bool, SetFullScreen<string>>(Method.SetFullscreen, new SetFullScreen<string>() { Fullscreen = fullscreen });
            } else {
                return SendRequest<bool, SetFullScreen<bool>>(Method.SetFullscreen, new SetFullScreen<bool>() { Fullscreen = fullscreen });
            }
        }

        public Task<bool> ShowNotification(string title, string message, ImageEnum image, int displaytime = 0) {
            return SendRequest<bool, ShowNotification>(Method.ShowNotification, new ShowNotification() { Title = title, Message = message, DisplayTime = displaytime, Image = image });
        }
    }
}
