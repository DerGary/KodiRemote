using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KInput;
using KodiRemote.Code.JSON.KInput.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class InputWebSocketService : WebSocketServiceBase, IInputService {
        #region Notifications
        public event ReceivedEventHandler OnInputFinished;
        public event ReceivedEventHandler<KInput.Notifications.Data> OnInputRequested;
        #endregion

        public InputWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.ExecuteAction
                || methods[guid] == Method.Home
                || methods[guid] == Method.SendText
                || methods[guid] == Method.ShowCodec
                || methods[guid] == Method.ShowOSD) {
                DeserializeMessageAndTriggerTask(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KInput.Notification.OnInputFinished.ToString()) {
                OnInputFinished?.Invoke();
            } else if (method == KInput.Notification.OnInputRequested.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KInput.Notifications.Data>>>(notification);
                OnInputRequested?.Invoke(item.Params.Data);
            }
        }

        public Task<bool> ExecuteAction(ExecActionEnum action) {
            return SendRequest<bool, ExecAction>(Method.ExecuteAction, new ExecAction() { Action = action });
        }

        public Task<bool> Home() {
            return SendRequest<bool>(Method.Home);
        }

        public Task<bool> SendText(string text, bool done = true) {
            return SendRequest<bool, SendText>(Method.SendText, new SendText() { Text = text, Done = done });
        }

        public Task<bool> ShowCodec() {
            return SendRequest<bool>(Method.ShowCodec);
        }

        public Task<bool> ShowOSD() {
            return SendRequest<bool>(Method.ShowOSD);
        }
    }
}
