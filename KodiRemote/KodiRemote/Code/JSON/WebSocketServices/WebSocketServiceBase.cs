using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public abstract class WebSocketServiceBase {
        protected RPCWebSocketHelper helper;
        public WebSocketServiceBase(RPCWebSocketHelper helper) {
            this.helper = helper;
            helper.ResponseReceived += ResponseReceived;
            helper.ErrorReceived += ErrorReceived;
            helper.NotificationReceived += NotificationReceived;
        }

        private void NotificationReceived(string method, string message) {
            WebSocketNotificationReceived(method, message);
        }

        private void ErrorReceived(string guid, RPCError error) {
            if (tasks.ContainsKey(guid)) {
                errors[guid] = error;
                tasks[guid].Start();
            }
        }

        private void ResponseReceived(string guid, string message) {
            if (!methods.ContainsKey(guid)) {
                return;
            }
            WebSocketMessageReceived(guid, message);
        }


        protected abstract void WebSocketMessageReceived(string guid, string message);
        protected abstract void WebSocketNotificationReceived(string method, string notification);

        protected void DeserializeNotificationAndTriggerEvent<T>(ReceivedEventHandler<T> eventHandler, string notification) {
            var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<T>>>(notification);
            eventHandler?.Invoke(item.Params.Data);
        }
        protected void DeserializeNotificationAndTriggerEvent(ReceivedEventHandler eventHandler, string notification) {
            eventHandler?.Invoke();
        }

        protected void DeserializeMessageAndTriggerTask<T>(string guid, string message) {
            var item = JsonSerializer.FromJson<RPCResponse<T>>(message);
            if (tasks.ContainsKey(guid)) {
                returnValues[guid] = item.Result;
                tasks[guid].Start();
                tasks.Remove(guid);
                methods.Remove(guid);
            }
        }
        /// <summary>
        /// Deserializes the message string to a RPCResponse and interprets the result string
        /// If the string is equal to OK, the return Value of the Task will be true otherwise false.
        /// If the Return Value is not of type string use the generics Method and provide the Return type as generic param
        /// </summary>
        protected void DeserializeMessageAndTriggerTask(string guid, string message) {
            var item = JsonSerializer.FromJson<RPCResponse<string>>(message);
            if (tasks.ContainsKey(guid)) {
                if (item.Result == "OK") {
                    returnValues[guid] = true;
                } else {
                    returnValues[guid] = false;
                }
                tasks[guid].Start();
                tasks.Remove(guid);
                methods.Remove(guid);
            }
        }

        protected void SendRequest<T>(StringEnum method, string guid, T param) {
            RPCRequest<T> request = new RPCRequest<T>(method, guid) {
                Params = param
            };
            helper.SendRequest(request);
        }
        protected void SendRequest(StringEnum method, string guid) {
            RPCRequest request = new RPCRequest(method, guid);
            helper.SendRequest(request);
        }

        protected Dictionary<string, Task> tasks = new Dictionary<string, Task>();
        protected Dictionary<string, object> returnValues = new Dictionary<string, object>();
        protected Dictionary<string, StringEnum> methods = new Dictionary<string, StringEnum>();
        protected Dictionary<string, RPCError> errors = new Dictionary<string, RPCError>();

        protected Task<T> SendRequest<T>(StringEnum method) {
            string guid = Guid.NewGuid().ToString();
            var t = PrepareTask<T>(method, guid);
            SendRequest(method, guid);
            return t;
        }
        protected Task<T> SendRequest<T, U>(StringEnum method, U param) {
            string guid = Guid.NewGuid().ToString();
            var t = PrepareTask<T>(method, guid);
            SendRequest<U>(method, guid, param);
            return t;
        }
        private Task<T> PrepareTask<T>(StringEnum method, string guid) {
            var t = new Task<T>(() => {
                if(errors.ContainsKey(guid) || !returnValues.ContainsKey(guid)) {
                    return default(T);
                }
                var ret = (T)returnValues[guid];
                returnValues.Remove(guid);
                return ret;
            });
            tasks[guid] = t;
            methods[guid] = method;
            return t;
        }
    }
}
