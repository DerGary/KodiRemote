using KodiRemote.Code.JSON.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IInputService {
        #region Notifications
        event ReceivedEventHandler OnInputFinished;
        event ReceivedEventHandler<KInput.Notifications.Data> OnInputRequested;
        #endregion Notifications

        Task<bool> SendText(string text, bool done = true);
        Task<bool> Home();
        Task<bool> ExecuteAction(ExecActionEnum action);
        Task<bool> ShowCodec();
        Task<bool> ShowOSD();
    }
}
