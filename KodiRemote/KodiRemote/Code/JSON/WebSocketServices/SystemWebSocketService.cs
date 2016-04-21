using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KSystem.Results;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KSystem;
using KodiRemote.Code.JSON.KGUI.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class SystemWebSocketService : WebSocketServiceBase, ISystemService {
        #region Notifications
        public event ReceivedEventHandler OnLowBattery;
        public event ReceivedEventHandler OnQuit;
        public event ReceivedEventHandler OnRestart;
        public event ReceivedEventHandler OnSleep;
        public event ReceivedEventHandler OnWake;
        #endregion Notifications

        public SystemWebSocketService(WebSocketHelper helper) : base(helper) { }
        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.EjectOpticalDrive
                || methods[guid] == Method.Hibernate
                || methods[guid] == Method.Reboot
                || methods[guid] == Method.Shutdown
                || methods[guid] == Method.Suspend) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<SystemProperties>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KSystem.Notification.OnLowBattery.ToString()) {
                OnLowBattery?.Invoke();
            } else if (method == KSystem.Notification.OnQuit.ToString()) {
                OnQuit?.Invoke();
            } else if (method == KSystem.Notification.OnRestart.ToString()) {
                OnRestart?.Invoke();
            } else if (method == KSystem.Notification.OnSleep.ToString()) {
                OnSleep?.Invoke();
            } else if (method == KSystem.Notification.OnWake.ToString()) {
                OnWake?.Invoke();
            }
        }


        public Task<bool> EjectOpticalDrive() {
            return SendRequest<bool>(Method.EjectOpticalDrive);
        }

        public Task<SystemProperties> GetProperties(SystemField properties = null) {
            return SendRequest<SystemProperties, GetProperties>(Method.EjectOpticalDrive, new GetProperties() { Properties = properties.ToList() });
        }

        public Task<bool> Hibernate() {
            return SendRequest<bool>(Method.Hibernate);
        }

        public Task<bool> Reboot() {
            return SendRequest<bool>(Method.Reboot);
        }

        public Task<bool> Shutdown() {
            return SendRequest<bool>(Method.Shutdown);
        }

        public Task<bool> Suspend() {
            return SendRequest<bool>(Method.Suspend);
        }
    }
}
