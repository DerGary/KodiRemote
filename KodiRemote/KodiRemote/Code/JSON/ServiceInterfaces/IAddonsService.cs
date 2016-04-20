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
        Task<bool> ExecuteAddon(string addonid, List<string> parameter = null, bool wait = false);
        Task<Addon> GetAddonDetails(string addonid, AddonField properties = null);
        Task<List<Addon>> GetAddons(ContentEnum content, EnabledEnum enabled, AddonField properties = null, string type = null, Limits limits = null);
        Task<bool> SetAddonEnabled(string addonid, ToggleEnum enabled);
    }
}
