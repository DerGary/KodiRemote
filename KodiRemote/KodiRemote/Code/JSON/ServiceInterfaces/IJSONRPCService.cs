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
        Task<Configuration> GetConfiguration();
        Task<JsonObject> Introspect(bool? getdescriptions = null, bool? getmetadata = null, bool? filterbytransport = null, Dictionary<string, object> filter = null);
        Task<bool> NotifyAll(string sender, string message);
        Task<Permissions> Permission();
        Task<bool> Ping();
        Task<KJSONRPC.Results.Version> Version();
        Task<Configuration> SetConfiguration(bool? gui = null, bool? other = null, bool? input = null, bool? videolibrary = null, bool? audiolibrary = null, bool? playlist = null, bool? system = null, bool? player = null, bool? application = null, bool? pvr = null);
    }
}
