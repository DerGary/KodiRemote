using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON {
    [DataContract]
    public class RPCBase {
        [DataMember(Name = "jsonrpc")]
        public string JsonRPC { get; set; } = "2.0";
    }

    [DataContract]
    public class RPCError {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "data")]
        public object Data { get; set; }
    }

    [DataContract]
    public class RPCNotification : RPCBase {
        [DataMember(Name = "method")]
        public string Method { get; set; }
    }
    [DataContract]
    public class RPCNotification<T> : RPCNotification where T : NotificationParams {
        [DataMember(Name = "params")]
        public T Params { get; set; }
    }

    [DataContract]
    public class NotificationParams {
        [DataMember(Name = "sender")]
        public string Sender { get; set; }
    }
    [DataContract]
    public class NotificationParams<T> : NotificationParams {
        [DataMember(Name = "data")]
        public T Data { get; set; }
    }


    

    [DataContract]
    public class RPC : RPCBase {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }


    [DataContract]
    public class RPCRequest : RPC {
        [DataMember(Name = "method")]
        public string Method { get; set; }

        public RPCRequest() { }
        public RPCRequest(StringEnum method, string guid) : this() {
            Method = method;
            Id = guid;
        }

    }

    [DataContract]
    public class RPCRequest<T> : RPCRequest {
        [DataMember(Name = "params")]
        public T Params { get; set; }
        public RPCRequest() : base() { }
        public RPCRequest(StringEnum method, string guid) : base(method, guid) {
        }
    }
    [DataContract]
    public class RPCResponse : RPC {
        [DataMember(Name = "error")]
        public RPCError Error { get; set; }
    }

    [DataContract]
    public class RPCResponse<T> : RPCResponse {
        [DataMember(Name = "result")]
        public T Result { get; set; }
    }

}
