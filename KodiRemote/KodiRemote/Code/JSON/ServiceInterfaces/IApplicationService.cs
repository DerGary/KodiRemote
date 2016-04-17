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


        event ReceivedEventHandler<KApplication.Results.ApplicationProperties> GetPropertiesReceived;
        event ReceivedEventHandler<bool> QuitReceived;
        event ReceivedEventHandler<bool> SetMuteReceived;
        event ReceivedEventHandler<bool> SetVolumeReceived;
        void GetProperties(ApplicationField properties);
        void Quit();
        void SetMute(ToggleEnum mute);
        void SetVolume(IncDecEnum volume);
        void SetVolume(int volume);
    }
}
