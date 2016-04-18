using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.KJSONRPC.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IJSONRPCService {
        event ReceivedEventHandler<Configuration> GetConfigurationReceived;
        event ReceivedEventHandler<JsonObject> IntrospectReceived;
        event ReceivedEventHandler<bool> NotifyAllReceived;
        event ReceivedEventHandler<Permissions> PermissionReceived;
        event ReceivedEventHandler<bool> PingReceived;
        event ReceivedEventHandler<APIVersion> VersionReceived;
        event ReceivedEventHandler<Configuration> SetConfigurationReceived;
        void GetConfiguration();
        void Introspect(bool? getdescriptions = null, bool? getmetadata = null, bool? filterbytransport = null, Dictionary<string, object> filter = null);
        void NotifyAll(string sender, string message);
        void Permission();
        void Ping();
        void Version();
        void SetConfiguration(bool? gui = null, bool? other = null, bool? input = null, bool? videolibrary = null, bool? audiolibrary = null, bool? playlist = null, bool? system = null, bool? player = null, bool? application = null, bool? pvr = null);
    }
}
