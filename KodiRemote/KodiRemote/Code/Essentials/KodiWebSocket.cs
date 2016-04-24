using KodiRemote.Code.JSON.General.Notifications;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    public class KodiWebSocket : Kodi, IDisposable {
        protected RPCWebSocketHelper Connection { get; set; }
        private Timer timer;

        private Item currentlyPlayingItem;
        public override Item CurrentlyPlayingItem {
            get {
                return currentlyPlayingItem;
            }
            protected set {
                currentlyPlayingItem = value;
                RaisePropertyChanged();
            }
        }

        private bool paused;
        public override bool Paused {
            get {
                return paused;
            }
            protected set {
                paused = value;
                RaisePropertyChanged();
            }
        }

        private bool muted;
        public override bool Muted {
            get {
                return muted;
            }
            protected set {
                muted = value;
                RaisePropertyChanged();
            }
        }

        private bool connected = true;
        public override bool Connected {
            get {
                return connected;
            }
            protected set {
                if (connected != value) {
                    connected = value;
                    if (!value) {
                        timer = new Timer(Timer_Tick, null, 0, (int)TimeSpan.FromSeconds(15).TotalMilliseconds);
                    } else if (timer != null) {
                        timer.Dispose();
                        timer = null;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public KodiWebSocket(KodiSettings settings) : base(settings) {
            Connection = new RPCWebSocketHelper();
            Connection.ConnectionClosed += ConnectionClosed;

            Playlist = new PlaylistWebSocketService(Connection);
            AudioLibrary = new AudioLibraryWebSocketService(Connection);
            VideoLibrary = new VideoLibraryWebSocketService(Connection);
            PVR = new PVRWebSocketService(Connection);
            JSONRPC = new JSONRPCWebSocketService(Connection);
            GUI = new GUIWebSocketService(Connection);
            Addons = new AddonsWebSocketService(Connection);
            System = new SystemWebSocketService(Connection);
            Files = new FilesWebSocketService(Connection);
            Application = new ApplicationWebSocketService(Connection);
            Application.OnVolumeChanged += Application_OnVolumeChanged;
            Input = new InputWebSocketService(Connection);
            Player = new PlayerWebSocketService(Connection);
            Player.OnPauseReceived += Player_OnPauseReceived;
            Player.OnPlayReceived += Player_OnPlayReceived;
            Player.OnSpeedChangedReceived += Player_OnSpeedChangedReceived;
            Player.OnStopReceived += Player_OnStopReceived;
        }

        private async void Timer_Tick(object state) {
            await Connect();
        }

        private void Application_OnVolumeChanged(JSON.KApplication.Notifications.Data item) {
            if (item.Muted) {
                Muted = true;
            } else {
                Muted = false;
            }
        }


        private void Player_OnStopReceived(JSON.KPlayer.Notifications.Stop item) {
            CurrentlyPlayingItem = null;
            Paused = false;
        }

        private void Player_OnSpeedChangedReceived(JSON.KPlayer.Notifications.Data item) {
            if (item.Player.Speed == 0) {
                Paused = true;
            }
        }

        private void Player_OnPlayReceived(JSON.KPlayer.Notifications.Data item) {
            CurrentlyPlayingItem = item.Item;
            Paused = false;
        }

        private void Player_OnPauseReceived(JSON.KPlayer.Notifications.Data item) {
            Paused = true;
        }

        private void ConnectionClosed(string message) {
            Connected = false;
        }

        public override async Task Connect() {
            Connected = await Connection.Connect(new Uri("ws://" + settings.Hostname + ":" + settings.Port + "/jsonrpc"));
        }


        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    timer.Dispose();
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }
                Connection.Dispose();
                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        ~KodiWebSocket() {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(false);
        }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public override void Dispose() {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
