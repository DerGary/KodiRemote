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
        public event ReceivedEventHandler<bool> ActivateWindowReceived;
        public event ReceivedEventHandler<GUIProperties> GetPropertiesReceived;
        public event ReceivedEventHandler<bool> SetFullscreenReceived;
        public event ReceivedEventHandler<bool> ShowNotificationReceived;

        public GUIWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == KGUI.Method.ActivateWindow.ToInt()) {
                ConvertResultToBool(ActivateWindowReceived, message);
            } else if (id == KGUI.Method.GetProperties.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetPropertiesReceived, message);
            } else if (id == KGUI.Method.SetFullscreen.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetFullscreenReceived, message);
            } else if (id == KGUI.Method.ShowNotification.ToInt()) {
                ConvertResultToBool(ShowNotificationReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //nothing to do here :D
        }


        public void ActivateWindow(WindowEnum window, List<string> parameters = null) {
            SendRequest(Method.ActivateWindow, new ActivateWindow() { Window = window, Parameters = parameters });
        }

        public void GetProperties(GUIField properties) {
            SendRequest(Method.GetProperties, new GetProperties() { Properties = properties.ToList() });
        }

        public void SetFullscreen(ToggleEnum fullscreen) {
            if (fullscreen == ToggleEnum.Toggle) {
                SendRequest(Method.SetFullscreen, new SetFullScreen<string>() { Fullscreen = fullscreen });
            } else {
                SendRequest(Method.SetFullscreen, new SetFullScreen<bool>() { Fullscreen = fullscreen });
            }
        }

        public void ShowNotification(string title, string message, ImageEnum image, int displaytime = 0) {
            SendRequest(Method.ShowNotification, new ShowNotification() { Title = title, Message = message, DisplayTime = displaytime, Image = image });
        }
    }
}
