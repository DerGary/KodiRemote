using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KSystem.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface ISystemService {
        #region Notifications
        event ReceivedEventHandler OnLowBattery;
        event ReceivedEventHandler OnQuit;
        event ReceivedEventHandler OnRestart;
        event ReceivedEventHandler OnSleep;
        event ReceivedEventHandler OnWake;
        #endregion Notifications

        Task<bool> EjectOpticalDrive();
        Task<SystemProperties> GetProperties(SystemField properties);
        Task<bool> Hibernate();
        Task<bool> Reboot();
        Task<bool> Shutdown();
        Task<bool> Suspend();
    }
}
