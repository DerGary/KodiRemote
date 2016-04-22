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
        public JSONRPCWebSocketService(WebSocketHelper helper) : base(helper) { }


        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.GetConfiguration) {
                DeserializeMessageAndTriggerTask<Configuration>(guid, message);
            } else if (methods[guid] == Method.Introspect) {
                DeserializeMessageAndTriggerTask<JsonObject>(guid, message);
            } else if (methods[guid] == Method.NotifyAll) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.Permission) {
                DeserializeMessageAndTriggerTask<Permissions>(guid, message);
            } else if (methods[guid] == Method.Ping) {
                var item = JsonSerializer.FromJson<RPCResponseWithStringId<string>>(message);
                if (item.Result == "pong") {
                    returnValues[guid] = true;
                } else {
                    returnValues[guid] = false;
                }
                tasks[guid].Start();
            } else if (methods[guid] == Method.SetConfiguration) {
                DeserializeMessageAndTriggerTask<Configuration>(guid, message);
            } else if (methods[guid] == Method.Version) {
                DeserializeMessageAndTriggerTask<KJSONRPC.Results.Version>(guid, message);
            }
        }


        protected override void WebSocketNotificationReceived(string method, string notification) {
            //dont need that
        }

        public Task<Configuration> GetConfiguration() {
            return SendRequest<Configuration>(Method.GetConfiguration);
        }

        public Task<JsonObject> Introspect(bool? getdescriptions = default(bool?), bool? getmetadata = default(bool?), bool? filterbytransport = default(bool?), Dictionary<string, object> filter = null) {
            return SendRequest<JsonObject, Introspect>(Method.Introspect, new Introspect() { Filter = filter, FilterByTransport = filterbytransport, GetDescriptions = getdescriptions, GetMetadata = getmetadata });
        }

        public Task<bool> NotifyAll(string sender, string message) {
            return SendRequest<bool, NotifyAll>(Method.NotifyAll, new NotifyAll() { Message = message, Sender = sender });
        }

        public Task<Permissions> Permission() {
            return SendRequest<Permissions>(Method.Permission);
        }

        public Task<bool> Ping() {
            return SendRequest<bool>(Method.Ping);
        }

        public Task<Configuration> SetConfiguration(bool? gui = default(bool?), bool? other = default(bool?), bool? input = default(bool?), bool? videolibrary = default(bool?), bool? audiolibrary = default(bool?), bool? playlist = default(bool?), bool? system = default(bool?), bool? player = default(bool?), bool? application = default(bool?), bool? pvr = default(bool?)) {
            return SendRequest<Configuration, SetConfiguration>(Method.SetConfiguration, new SetConfiguration() {
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

        public Task<KJSONRPC.Results.Version> Version() {
            return SendRequest<KJSONRPC.Results.Version>(Method.Version);
        }
    }
}
