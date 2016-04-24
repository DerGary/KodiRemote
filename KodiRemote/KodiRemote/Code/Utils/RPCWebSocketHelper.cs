using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace KodiRemote.Code.Utils {
    public class RPCWebSocketHelper : IDisposable {
        private WebSocketHelper helper;

        public delegate void ErrorReceivedEventHandler(string guid, RPCError error);
        public event ErrorReceivedEventHandler ErrorReceived;
        public delegate void ResponseReceivedEventHandler(string guid, string message);
        public event ResponseReceivedEventHandler ResponseReceived;
        public delegate void NotificationReceivedEventHandler(string method, string message);
        public event NotificationReceivedEventHandler NotificationReceived;

        public event WebSocketHelper.ConnectionClosedEventHandler ConnectionClosed;

        public RPCWebSocketHelper() {
            this.helper = new WebSocketHelper();
            helper.ConnectionClosed += (string message) => ConnectionClosed?.Invoke(message);
            helper.MessageReceived += Helper_MessageReceived;
        }

        public async Task<bool> Connect(Uri uri) {
            return await helper.Connect(uri);
        }

        private void Helper_MessageReceived(string message) {
            RPCResponse response = JsonSerializer.FromJson<RPCResponse>(message);
            if (response.Id != null) {
                if (response.Error == null) {
                    ResponseReceived?.Invoke(response.Id, message);
                } else {
                    ErrorReceived?.Invoke(response.Id, response.Error);
                }
            } else {
                //when no id is given the message must be a notification
                RPCNotification notification = JsonSerializer.FromJson<RPCNotification>(message);
                NotificationReceived?.Invoke(notification.Method, message);
            }
        }

        public async void SendRequest(RPC request) {
            try {
                string message = JsonSerializer.ToJson(request);
                await helper.SendMessage(message);
            } catch {
                await new MessageDialog("Der Befehl konnte nicht ausgeführt werden, da keine Verbindung zu Kodi aufgebaut werden konnte.", "Anforderung fehlgeschlagen").ShowAsync();
                ErrorReceived?.Invoke(request.Id, null);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }

                helper.Dispose();
                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        ~RPCWebSocketHelper() {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(false);
        }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose() {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
