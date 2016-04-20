using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public abstract class WebSocketServiceBase {
        protected WebSocketHelper helper;
        public WebSocketServiceBase(WebSocketHelper helper) {
            this.helper = helper;
            helper.MessageReceived += MessageReceived;
        }

        protected void MessageReceived(string message) {
            RPCResponseWithStringId response = JsonSerializer.FromJson<RPCResponseWithStringId>(message);
            if (response.Id != null) {
                if (response.Error == null) {
                    WebSocketMessageReceived(response.Id, message);
                } else {
                    //Todo: Panik
                    Debug.WriteLine("error occured: " + message);
                }
            } else {
                //when no id is given the message must be a notification
                RPCNotification notification = JsonSerializer.FromJson<RPCNotification>(message);
                WebSocketNotificationReceived(notification.Method, message);
            }
        }

        protected virtual void WebSocketMessageReceived(string guid, string message) { }
        protected abstract void WebSocketMessageReceived(int id, string message);
        protected abstract void WebSocketNotificationReceived(string method, string notification);

        protected void ConvertResultToBool(ReceivedEventHandler<bool> eventHandler, string message) {
            var item = JsonSerializer.FromJson<RPCResponse<string>>(message);
            if (item.Result == "OK") {
                eventHandler?.Invoke(true);
            } else {
                eventHandler?.Invoke(false);
            }
        }
        protected void DeserializeMessageAndTriggerEvent<T>(ReceivedEventHandler<T> eventHandler, string message) {
            var item = JsonSerializer.FromJson<RPCResponse<T>>(message);
            eventHandler?.Invoke(item.Result);
        }
        protected void DeserializeNotificationAndTriggerEvent<T>(ReceivedEventHandler<T> eventHandler, string notification) {
            var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<T>>>(notification);
            eventHandler?.Invoke(item.Params.Data);
        }
        protected void DeserializeNotificationAndTriggerEvent(ReceivedEventHandler eventHandler, string notification) {
            eventHandler?.Invoke();
        }

        #region old
        protected void SendRequest<T>(StringEnum method, T param) {
            RPCRequest<T> request = new RPCRequest<T>(method) {
                Params = param
            };
            helper.SendRequest(request);
        }
        protected void SendRequest(StringEnum method) {
            RPCRequest request = new RPCRequest(method);
            helper.SendRequest(request);
        }
        #endregion

        protected void DeserializeMessageAndTriggerTask<T>(string guid, string message) {
            var item = JsonSerializer.FromJson<RPCResponseWithStringId<T>>(message);
            returnValues[guid] = item.Result;
            tasks[guid].Start();
        }
        protected void DeserializeMessageAndTriggerTask(string guid, string message) {
            var item = JsonSerializer.FromJson<RPCResponseWithStringId<string>>(message);
            if (item.Result == "OK") {
                returnValues[guid] = true;
            } else {
                returnValues[guid] = false;
            }
            tasks[guid].Start();
        }

        protected void SendRequestWithGuid<T>(StringEnum method, string guid, T param) {
            RPCRequestWithStringId<T> request = new RPCRequestWithStringId<T>(method, guid) {
                Params = param
            };
            helper.SendRequest(request);
        }
        protected void SendRequestWithGuid(StringEnum method, string guid) {
            RPCRequestWithStringId request = new RPCRequestWithStringId(method, guid);
            helper.SendRequest(request);
        }

        protected Dictionary<string, Task> tasks = new Dictionary<string, Task>();
        protected Dictionary<string, object> returnValues = new Dictionary<string, object>();
        protected Dictionary<string, int> methods = new Dictionary<string, int>();

        protected Task<T> SendRequest<T>(StringEnum method) {
            string guid = new Guid().ToString();
            var t = PrepareTask<T>(method, guid);
            SendRequestWithGuid(method, guid);
            return t;
        }
        protected Task<T> SendRequest<T, U>(StringEnum method, U param) {
            string guid = new Guid().ToString();
            var t = PrepareTask<T>(method, guid);
            SendRequestWithGuid<U>(method, guid, param);
            return t;
        }
        private Task<T> PrepareTask<T>(StringEnum method, string guid) {
            var t = new Task<T>(() => {
                return (T)returnValues[guid];
            });
            tasks[guid] = t;
            methods[guid] = method.ToInt();
            return t;
        }
    }
}
