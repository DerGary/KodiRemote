using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IApplicationService {
        #region Notifications
        event ReceivedEventHandler<KApplication.Notifications.Data> OnVolumeChanged;
        #endregion Notifications

        Task<KApplication.Results.ApplicationProperties> GetProperties(ApplicationField properties);
        Task<bool> Quit();
        Task<bool> SetMute(ToggleEnum mute);
        Task<int> SetVolume(IncDecEnum volume);
        Task<int> SetVolume(int volume);
    }
}
