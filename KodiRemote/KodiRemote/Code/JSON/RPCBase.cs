using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON
{
    [DataContract]
    public class RPCBase
    {
        [DataMember(Name = "jsonrpc")]
        public string JsonRPC { get; set; } = "2.0";
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
    [DataContract]
    public class RPCRequest : RPCBase
    {
        [DataMember(Name = "method")]
        public string Method { get; set; }
    }
    [DataContract]
    public class RPCRequest<T> : RPCRequest
    {
        [DataMember(Name = "params")]
        public T Params { get; set; }
    }

    [DataContract]
    public class RPCResponse<T> : RPCBase
    {
        [DataMember(Name = "result")]
        public T Result { get; set; }
        [DataMember(Name = "error")]
        public RPCError Error { get; set; }
    }

    [DataContract]
    public class RPCError
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "data")]
        public object Data { get; set; }
    }

    [DataContract]
    public class Player
    {
        [DataMember(Name ="playerid")]
        public int PlayerId { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    //public class Service : IPlayerService
    //{
    //    //public async Task<List<Player>> GetActivePlayers()
    //    //{
    //    //    RPCRequest request = new RPCRequest() { Method = "Player.GetActivePlayers" };
    //    //    string json = JsonSerializer.ToJson(request);

    //    //}
    //}
    public interface IPlayerService
    {
        Task<List<Player>> GetActivePlayers();
        //Task<Item> GetItem(int playerid, ItemField properties = null);
        //Task<PlayerProperties> GetProperties(int playerid, PlayerField properties)
        //Task<bool> GoTo(int playerid, ToEnum to)
    }
    
}
