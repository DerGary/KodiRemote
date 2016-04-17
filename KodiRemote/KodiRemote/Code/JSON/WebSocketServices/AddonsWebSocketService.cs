using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KAddons.Results;
using KodiRemote.Code.JSON.KApplication.Notifications;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KAddons;
using KodiRemote.Code.JSON.KAddons.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class AddonsWebSocketService : WebSocketServiceBase, IAddonsService {
        public event ReceivedEventHandler<bool> ExecuteAddonReceived;
        public event ReceivedEventHandler<Addon> GetAddonDetailsReceived;
        public event ReceivedEventHandler<List<Addon>> GetAddonsReceived;
        public event ReceivedEventHandler<bool> SetAddonEnabledReceived;

        public AddonsWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.ExecuteAddon.ToInt()) {
                ConvertResultToBool(ExecuteAddonReceived, message);
            } else if (id == Method.GetAddonDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Addon>>(message);
                GetAddonDetailsReceived?.Invoke(item.Result);
            } else if (id == Method.GetAddons.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<Addon>>>(message);
                GetAddonsReceived?.Invoke(item.Result);
            } else if (id == Method.SetAddonEnabled.ToInt()) {
                ConvertResultToBool(SetAddonEnabledReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //nothing to do here :D
        }


        public void ExecuteAddon(string addonid, List<string> parameter = null, bool wait = false) {
            SendRequest(Method.ExecuteAddon, new ExecuteAddon() { AddonId = addonid, Wait = wait, Params = parameter });
        }

        public void GetAddonDetails(string addonid, AddonField properties = null) {
            SendRequest(Method.GetAddonDetails, new GetAddonDetails() { AddonId = addonid, Properties = properties?.ToList() });
        }

        public void GetAddons(ContentEnum content, EnabledEnum enabled, AddonField properties = null, string type = null, Limits limits = null) {
            SendRequest(Method.GetAddons, new GetAddons() { Properties = properties?.ToList(), Type = type, Limits = limits, Content = content, Enabled = enabled });
        }

        public void SetAddonEnabled(string addonid, ToggleEnum enabled) {
            if (enabled == ToggleEnum.Toggle) {
                SendRequest(Method.SetAddonEnabled, new SetAddonEnabled<string>() { AddonId = addonid, Enabled = enabled });
            } else {
                SendRequest(Method.SetAddonEnabled, new SetAddonEnabled<bool>() { AddonId = addonid, Enabled = enabled });
            }
        }

    }
}
