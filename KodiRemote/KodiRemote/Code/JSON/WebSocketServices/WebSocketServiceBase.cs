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
            RPCResponse response = JsonSerializer.FromJson<RPCResponse>(message);
            if (response.Id != 0) {
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

        protected abstract void WebSocketMessageReceived(int id, string message);
        protected abstract void WebSocketNotificationReceived(string method, string notification);
    }
}
