using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KApplication.Notifications;
using KodiRemote.Code.JSON.KApplication.Results;
using KodiRemote.Code.JSON.KApplication;
using KodiRemote.Code.JSON.KApplication.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class ApplicationWebSocketService : WebSocketServiceBase, IApplicationService {
        #region Notifications
        public event ReceivedEventHandler<Data> OnVolumeChanged;
        #endregion Notifications

        #region Events
        public event ReceivedEventHandler<ApplicationProperties> GetPropertiesReceived;
        public event ReceivedEventHandler<bool> QuitReceived;
        public event ReceivedEventHandler<bool> SetMuteReceived;
        public event ReceivedEventHandler<int> SetVolumeReceived;
        #endregion Events

        public ApplicationWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.GetProperties.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetPropertiesReceived, message);
            } else if (id == Method.Quit.ToInt()) {
                ConvertResultToBool(QuitReceived, message);
            } else if (id == Method.SetMute.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetMuteReceived, message);
            } else if (id == Method.SetVolume.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetVolumeReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KApplication.Notification.OnVolumeChanged.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KApplication.Notifications.Data>>>(notification);
                OnVolumeChanged?.Invoke(item.Params.Data);
            }
        }

        public void GetProperties(ApplicationField properties) {
            if (properties == null) {
                throw new ArgumentException("properties");
            }
            SendRequest(Method.GetProperties, new Properties() { PropertiesValue = properties.ToList() });
        }

        public void Quit() {
            SendRequest(Method.Quit);
        }

        public void SetMute(ToggleEnum mute) {
            if (mute == ToggleEnum.Toggle) {
                SendRequest(Method.SetMute, new Mute<string>() { MuteValue = mute });
            } else {
                SendRequest(Method.SetMute, new Mute<bool>() { MuteValue = mute });
            }
        }

        public void SetVolume(int volume) {
            SendRequest(Method.SetVolume, new Volume<int>() { VolumeValue = volume });
        }

        public void SetVolume(IncDecEnum volume) {
            SendRequest(Method.SetVolume, new Volume<string>() { VolumeValue = volume });
        }
    }
}
