using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.Web;

namespace KodiRemote.Code.Utils {
    public class WebSocketHelper : IDisposable {
        private MessageWebSocket messageWebSocket;
        private DataWriter messageWriter;

        public delegate void MessageReceivedEventHandler(string message);
        public event MessageReceivedEventHandler MessageReceived;

        public delegate void ConnectionClosedEventHandler(string message);
        public event ConnectionClosedEventHandler ConnectionClosed;

        public async Task<bool> Connect(Uri uri) {
            try {
                MessageWebSocket webSocket = new MessageWebSocket();
                // MessageWebSocket supports both utf8 and binary messages.
                // When utf8 is specified as the messageType, then the developer
                // promises to only send utf8-encoded data.
                webSocket.Control.MessageType = SocketMessageType.Utf8;
                // Set up callbacks
                webSocket.MessageReceived += Message_Received;
                webSocket.Closed += Closed;

                await webSocket.ConnectAsync(uri);
                messageWebSocket = webSocket;
                messageWriter = new DataWriter(webSocket.OutputStream);
                Debug.WriteLine("Connected");
                return true;
            } catch (Exception ex) {
                WebErrorStatus status = WebSocketError.GetStatus(ex.GetBaseException().HResult);
                Debug.WriteLine(status);
            }
            return false;
        }

        private void Closed(IWebSocket sender, WebSocketClosedEventArgs args) {
            // You can add code to log or display the code and reason
            // for the closure (stored in args.Code and args.Reason)

            // This is invoked on another thread so use Interlocked 
            // to avoid races with the Start/Close/Reset methods.
            Debug.WriteLine("ConnectionClosed Code: " + args.Code + " Reason: " + args.Reason);
            MessageWebSocket webSocket = Interlocked.Exchange(ref messageWebSocket, null);
            DataWriter writer = Interlocked.Exchange(ref messageWriter, null);
            if (webSocket != null) {
                webSocket.Dispose();
                messageWebSocket = null;
            }
            if (writer != null) {
                writer.Dispose();
                messageWriter = null;
            }
            ConnectionClosed?.Invoke(args.Reason);
        }

        private void Closed(WebErrorStatus status) {
            if (messageWebSocket != null) {
                messageWebSocket.Dispose();
            }
        }

        private void Message_Received(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args) {
            try {
                using (DataReader reader = args.GetDataReader()) {
                    reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                    string message = reader.ReadString(reader.UnconsumedBufferLength);
                    Debug.WriteLine("Received Message: " + message);
                    MessageReceived?.Invoke(message);
                }
            } catch (Exception ex) // For debugging
            {
                WebErrorStatus status = WebSocketError.GetStatus(ex.GetBaseException().HResult);
                // Add your specific error-handling code here.
                Debug.WriteLine(status);
                Closed(status);
            }
        }

        public async Task SendMessage(string message) {
            if (messageWriter == null) {
                throw new InvalidOperationException("Websocket must be connected first");
            }
            Debug.WriteLine("Send Message: " + message);
            // Buffer any data we want to send.
            messageWriter.WriteString(message);

            // Send the data as one complete message.
            await messageWriter.StoreAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.
                if (messageWebSocket != null) {
                    messageWebSocket.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        ~WebSocketHelper() {
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
