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

        public AddonsWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.ExecuteAddon
                || methods[guid] == Method.SetAddonEnabled) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetAddonDetails) {
                DeserializeMessageAndTriggerTask<Addon>(guid, message);
            } else if (methods[guid] == Method.GetAddons) {
                DeserializeMessageAndTriggerTask<Addon>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //nothing to do here :D
        }


        public Task<bool> ExecuteAddon(string addonid, List<string> parameter = null, bool wait = false) {
            return SendRequest<bool, ExecuteAddon>(Method.ExecuteAddon, new ExecuteAddon() { AddonId = addonid, Wait = wait, Params = parameter });
        }

        public Task<Addon> GetAddonDetails(string addonid, AddonField properties = null) {
            return SendRequest<Addon, GetAddonDetails>(Method.GetAddonDetails, new GetAddonDetails() { AddonId = addonid, Properties = properties?.ToList() });
        }

        public Task<List<Addon>> GetAddons(ContentEnum content, EnabledEnum enabled, AddonField properties = null, string type = null, Limits limits = null) {
            return SendRequest<List<Addon>, GetAddons>(Method.GetAddons, new GetAddons() { Properties = properties?.ToList(), Type = type, Limits = limits, Content = content, Enabled = enabled });
        }

        public Task<bool> SetAddonEnabled(string addonid, ToggleEnum enabled) {
            if (enabled == ToggleEnum.Toggle) {
                return SendRequest<bool, SetAddonEnabled<string>>(Method.SetAddonEnabled, new SetAddonEnabled<string>() { AddonId = addonid, Enabled = enabled });
            } else {
                return SendRequest<bool, SetAddonEnabled<bool>>(Method.SetAddonEnabled, new SetAddonEnabled<bool>() { AddonId = addonid, Enabled = enabled });
            }
        }
    }
}
