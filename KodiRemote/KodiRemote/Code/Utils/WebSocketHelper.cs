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
using Windows.Web;

namespace KodiRemote.Code.Utils {
    public class WebSocketHelper {
        private MessageWebSocket messageWebSocket;
        private DataWriter messageWriter;

        public delegate void MessageReceivedEventHandler(string message);
        public event MessageReceivedEventHandler MessageReceived;

        public delegate void ConnectionClosedEventHandler(string message);
        public event ConnectionClosedEventHandler ConnectionClosed;

        public async Task Connect(Uri uri) {
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
            } catch (Exception ex) {
                WebErrorStatus status = WebSocketError.GetStatus(ex.GetBaseException().HResult);
                Debug.WriteLine(status);
            }
        }

        private void Closed(IWebSocket sender, WebSocketClosedEventArgs args) {
            // You can add code to log or display the code and reason
            // for the closure (stored in args.Code and args.Reason)

            // This is invoked on another thread so use Interlocked 
            // to avoid races with the Start/Close/Reset methods.
            MessageWebSocket webSocket = Interlocked.Exchange(ref messageWebSocket, null);
            if (webSocket != null) {
                webSocket.Dispose();
            }
            ConnectionClosed(args.Reason);
        }

        private void Message_Received(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args) {
            try {
                using (DataReader reader = args.GetDataReader()) {
                    reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                    string message = reader.ReadString(reader.UnconsumedBufferLength);
                    Debug.WriteLine(message);
                    MessageReceived(message);
                }
            } catch (Exception ex) // For debugging
              {
                WebErrorStatus status = WebSocketError.GetStatus(ex.GetBaseException().HResult);
                // Add your specific error-handling code here.
                Debug.WriteLine(status);
            }
        }

        public async void SendMessage(string message) {
            if (messageWriter == null) {
                throw new InvalidOperationException("Websocket must be connected first");
            }

            // Buffer any data we want to send.
            messageWriter.WriteString(message);

            // Send the data as one complete message.
            await messageWriter.StoreAsync();
        }
        public async void SendRequest(RPCRequest request) {
            if (messageWriter == null) {
                throw new InvalidOperationException("Websocket must be connected first");
            }

            string message = JsonSerializer.ToJson(request);

            // Buffer any data we want to send.
            messageWriter.WriteString(message);

            // Send the data as one complete message.
            await messageWriter.StoreAsync();
        }
    }
}
