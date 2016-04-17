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


        event ReceivedEventHandler<bool> EjectOpticalDriveReceived;
        event ReceivedEventHandler<SystemProperties> GetPropertiesReceived;
        event ReceivedEventHandler<bool> HibernateReceived;
        event ReceivedEventHandler<bool> RebootReceived;
        event ReceivedEventHandler<bool> ShutdownReceived;
        event ReceivedEventHandler<bool> SuspendReceived;
        void EjectOpticalDrive();
        void GetProperties(SystemField properties = null);
        void Hibernate();
        void Reboot();
        void Shutdown();
        void Suspend();
    }
}
