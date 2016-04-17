using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KAddons.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IAddonsService {
        event ReceivedEventHandler<bool> ExecuteAddonReceived;
        event ReceivedEventHandler<Addon> GetAddonDetailsReceived;
        event ReceivedEventHandler<List<Addon>> GetAddonsReceived;
        event ReceivedEventHandler<bool> SetAddonEnabledReceived;
        void ExecuteAddon(string addonid, List<string> parameter = null, bool wait = false);
        void GetAddonDetails(string addonid, AddonField properties = null);
        void GetAddons(ContentEnum content, EnabledEnum enabled, AddonField properties = null, string type = null, Limits limits = null);
        void SetAddonEnabled(string addonid, ToggleEnum enabled);
    }
}
