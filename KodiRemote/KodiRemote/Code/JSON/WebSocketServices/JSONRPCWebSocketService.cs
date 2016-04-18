using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.KJSONRPC.Results;
using KodiRemote.Code.JSON.KJSONRPC;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using Windows.Data.Json;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class JSONRPCWebSocketService : WebSocketServiceBase, IJSONRPCService {
        #region Events
        public event ReceivedEventHandler<Configuration> GetConfigurationReceived;
        public event ReceivedEventHandler<JsonObject> IntrospectReceived;
        public event ReceivedEventHandler<bool> NotifyAllReceived;
        public event ReceivedEventHandler<Permissions> PermissionReceived;
        public event ReceivedEventHandler<bool> PingReceived;
        public event ReceivedEventHandler<Configuration> SetConfigurationReceived;
        public event ReceivedEventHandler<APIVersion> VersionReceived;
        #endregion Events

        public JSONRPCWebSocketService(WebSocketHelper helper) : base(helper) { }
        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.GetConfiguration.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Configuration>>(message);
                GetConfigurationReceived?.Invoke(item.Result);
            } else if (id == Method.Introspect.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<JsonObject>>(message);
                IntrospectReceived?.Invoke(item.Result);
            } else if (id == Method.NotifyAll.ToInt()) {
                ConvertResultToBool(NotifyAllReceived, message);
            } else if (id == Method.Permission.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Permissions>>(message);
                PermissionReceived?.Invoke(item.Result);
            } else if (id == Method.Ping.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<string>>(message);
                if (item.Result == "pong") {
                    PingReceived?.Invoke(true);
                } else {
                    PingReceived?.Invoke(false);
                }
            } else if (id == Method.SetConfiguration.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Configuration>>(message);
                SetConfigurationReceived?.Invoke(item.Result);
            } else if (id == Method.Version.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<KJSONRPC.Results.Version>>(message);
                VersionReceived?.Invoke(item.Result.VersionValue);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //dont need that
        }

        public void GetConfiguration() {
            SendRequest(Method.GetConfiguration);
        }

        public void Introspect(bool? getdescriptions = null, bool? getmetadata = null, bool? filterbytransport = null, Dictionary<string, object> filter = null) {
            SendRequest(Method.Introspect, new Introspect() { Filter = filter, FilterByTransport = filterbytransport, GetDescriptions = getdescriptions, GetMetadata = getmetadata });
        }

        public void NotifyAll(string sender, string message) {
            SendRequest(Method.NotifyAll, new NotifyAll() { Message = message, Sender = sender });
        }

        public void Permission() {
            SendRequest(Method.Permission);
        }

        public void Ping() {
            SendRequest(Method.Ping);
        }

        public void SetConfiguration(bool? gui = null, bool? other = null, bool? input = null, bool? videolibrary = null, bool? audiolibrary = null, bool? playlist = null, bool? system = null, bool? player = null, bool? application = null, bool? pvr = null) {
            SendRequest(Method.SetConfiguration, new SetConfiguration() {
                Notifications = new Notifications() {
                    Application = application,
                    AudioLibrary = audiolibrary,
                    GUI = gui,
                    Input = input,
                    Other = other,
                    Player = player,
                    Playlist = playlist,
                    System = system,
                    VideoLibrary = videolibrary,
                    PVR = pvr
                }
            });
        }

        public void Version() {
            SendRequest(Method.Version);
        }
    }
}
