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

        #region Events
        public event ReceivedEventHandler<bool> EjectOpticalDriveReceived;
        public event ReceivedEventHandler<SystemProperties> GetPropertiesReceived;
        public event ReceivedEventHandler<bool> HibernateReceived;
        public event ReceivedEventHandler<bool> RebootReceived;
        public event ReceivedEventHandler<bool> ShutdownReceived;
        public event ReceivedEventHandler<bool> SuspendReceived;
        #endregion Events

        public SystemWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == KSystem.Method.EjectOpticalDrive.ToInt()) {
                ConvertResultToBool(EjectOpticalDriveReceived, message);
            } else if (id == KSystem.Method.GetProperties.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<SystemProperties>>(message);
                GetPropertiesReceived?.Invoke(item.Result);
            } else if (id == KSystem.Method.Hibernate.ToInt()) {
                ConvertResultToBool(HibernateReceived, message);
            } else if (id == KSystem.Method.Reboot.ToInt()) {
                ConvertResultToBool(RebootReceived, message);
            } else if (id == KSystem.Method.Shutdown.ToInt()) {
                ConvertResultToBool(ShutdownReceived, message);
            } else if (id == KSystem.Method.Suspend.ToInt()) {
                ConvertResultToBool(SuspendReceived, message);
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


        public void EjectOpticalDrive() {
            SendRequest(Method.EjectOpticalDrive);
        }

        public void GetProperties(SystemField properties = null) {
            SendRequest(Method.EjectOpticalDrive, new GetProperties() { Properties = properties.ToList() });
        }

        public void Hibernate() {
            SendRequest(Method.Hibernate);
        }

        public void Reboot() {
            SendRequest(Method.Reboot);
        }

        public void Shutdown() {
            SendRequest(Method.Shutdown);
        }

        public void Suspend() {
            SendRequest(Method.Suspend);
        }
    }
}
