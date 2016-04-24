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


        public ApplicationWebSocketService(RPCWebSocketHelper helper) : base(helper) { }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KApplication.Notification.OnVolumeChanged.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<Data>>>(notification);
                OnVolumeChanged?.Invoke(item.Params.Data);
            }
        }


        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<ApplicationProperties>(guid, message);
            } else if (methods[guid] == Method.Quit) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.SetMute) {
                DeserializeMessageAndTriggerTask<bool>(guid, message);
            } else if (methods[guid] == Method.SetVolume) {
                DeserializeMessageAndTriggerTask<int>(guid, message);
            }
        }

        public Task<ApplicationProperties> GetProperties(ApplicationField properties) {
            if (properties == null) {
                throw new ArgumentException("properties");
            }
            return SendRequest<ApplicationProperties, GetProperties>(Method.GetProperties, new GetProperties() { Properties = properties.ToList() });
        }

        public Task<bool> Quit() {
            return SendRequest<bool>(Method.Quit);
        }

        public Task<bool> SetMute(ToggleEnum mute) {
            if (mute == ToggleEnum.Toggle) {
                return SendRequest<bool, SetMute<string>>(Method.SetMute, new SetMute<string>() { MuteValue = mute });
            } else {
                return SendRequest<bool, SetMute<bool>>(Method.SetMute, new SetMute<bool>() { MuteValue = mute });
            }
        }

        public Task<int> SetVolume(int volume) {
            return SendRequest<int, SetVolume<int>>(Method.SetVolume, new SetVolume<int>() { VolumeValue = volume });
        }

        public Task<int> SetVolume(IncDecEnum volume) {
            return SendRequest<int, SetVolume<string>>(Method.SetVolume, new SetVolume<string>() { VolumeValue = volume });
        }
    }
}
