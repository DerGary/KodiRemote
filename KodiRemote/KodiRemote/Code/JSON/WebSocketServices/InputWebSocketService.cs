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

        #region Events
        public event ReceivedEventHandler<bool> ExecuteActionReceived;
        public event ReceivedEventHandler<bool> HomeReceived;
        public event ReceivedEventHandler<bool> SendTextReceived;
        public event ReceivedEventHandler<bool> ShowCodecReceived;
        public event ReceivedEventHandler<bool> ShowOSDReceived;
        #endregion

        public InputWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == KInput.Method.ExecuteAction.ToInt()) {
                ConvertResultToBool(ExecuteActionReceived, message);
            } else if (id == KInput.Method.Home.ToInt()) {
                ConvertResultToBool(HomeReceived, message);
            } else if (id == KInput.Method.SendText.ToInt()) {
                ConvertResultToBool(SendTextReceived, message);
            } else if (id == KInput.Method.ShowCodec.ToInt()) {
                ConvertResultToBool(ShowCodecReceived, message);
            } else if (id == KInput.Method.ShowOSD.ToInt()) {
                ConvertResultToBool(ShowOSDReceived, message);
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

        public void ExecuteAction(ExecActionEnum action) {
            SendRequest(Method.ExecuteAction, new ExecAction() { Action = action });
        }

        public void Home() {
            SendRequest(Method.Home);
        }

        public void SendText(string text, bool done = true) {
            SendRequest(Method.ExecuteAction, new SendText() { Text = text, Done = done });
        }

        public void ShowCodec() {
            SendRequest(Method.ShowCodec);
        }

        public void ShowOSD() {
            SendRequest(Method.ShowOSD);
        }


    }
}
