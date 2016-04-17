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


        event ReceivedEventHandler<bool> SendTextReceived;
        event ReceivedEventHandler<bool> HomeReceived;
        event ReceivedEventHandler<bool> ExecuteActionReceived;
        event ReceivedEventHandler<bool> ShowCodecReceived;
        event ReceivedEventHandler<bool> ShowOSDReceived;
        void SendText(string text, bool done = true);
        void Home();
        void ExecuteAction(ExecActionEnum action);
        void ShowCodec();
        void ShowOSD();

    }
}
