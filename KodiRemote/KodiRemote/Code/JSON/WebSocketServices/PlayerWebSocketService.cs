
using KodiRemote.Code.JSON.ServiceInterfaces;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.Params;
using KodiRemote.Code.JSON.KPlayer.Results;
using KodiRemote.Code.JSON.KPlayer;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class PlayerWebSocketService : WebSocketServiceBase, IPlayerService {
        public event ReceivedEventHandler<Item> ItemReceived;
        public event ReceivedEventHandler<List<Player>> PlayersReceived;
        public event ReceivedEventHandler<PlayerProperties> PropertiesReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnPlayReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnPauseReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnSpeedChangedReceived;

        public PlayerWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.GetItem.ToInt()) {
                RPCResponse<ItemResult> item = JsonSerializer.FromJson<RPCResponse<ItemResult>>(message);
                ItemReceived(item.Result.Item);
            } else if (id == Method.GetActivePlayers.ToInt()) {
                RPCResponse<List<Player>> item = JsonSerializer.FromJson<RPCResponse<List<Player>>>(message);
                PlayersReceived(item.Result);
            } else if (id == Method.GetProperties.ToInt()) {
                RPCResponse<PlayerProperties> item = JsonSerializer.FromJson<RPCResponse<PlayerProperties>>(message);
                PropertiesReceived(item.Result);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == Notification.OnPause.ToString()) {
                RPCNotification<NotificationParams<KPlayer.Notifications.Data>> not = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnPauseReceived(not.Params.Data);
            } else if (method == Notification.OnPlay.ToString()) {
                RPCNotification<NotificationParams<KPlayer.Notifications.Data>> not = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnPlayReceived(not.Params.Data);
            } else if (method == Notification.OnSpeedChanged.ToString()) {
                RPCNotification<NotificationParams<KPlayer.Notifications.Data>> not = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnSpeedChangedReceived(not.Params.Data);
            }
        }

        public void GetItem(int playerid, ItemField properties = null) {
            if (properties == null) {
                properties = new ItemField();
                properties.All();
            }
            RPCRequest<ActivePlayerParams> request = new RPCRequest<ActivePlayerParams>(Method.GetItem) {
                Params = new ActivePlayerParams(playerid, properties)
            };
            helper.SendRequest(request);
        }

        public void GetActivePlayers() {
            RPCRequest request = new RPCRequest(Method.GetActivePlayers);
            helper.SendRequest(request);
        }

        public void GetProperties(int playerid, PlayerField properties = null) {
            if (properties == null) {
                properties = new PlayerField();
                properties.All();
            }
            RPCRequest<ActivePlayerParams> request = new RPCRequest<ActivePlayerParams>(Method.GetProperties) {
                Params = new ActivePlayerParams(playerid, properties)
            };
            helper.SendRequest(request);
        }
    }
}
