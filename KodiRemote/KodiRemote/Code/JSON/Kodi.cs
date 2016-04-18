﻿using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.ServiceInterfaces;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace KodiRemote.Code.JSON {
    public class ActiveKodi : Kodi {
        private WebSocketHelper Connection { get; set; }
        public IPlayerService Player { get; private set; }
        public IInputService Input { get; private set; }
        public IApplicationService Application { get; private set; }
        public IGUIService GUI { get; private set; }
        public ISystemService System { get; private set; }
        public IAddonsService Addons { get; private set; }
        public IFilesService Files { get; private set; }
        public IJSONRPCService JSONRPC { get; private set; }
        public IPVRService PVR { get; private set; }
        public IVideoLibraryService VideoLibrary { get; private set; }

        private bool connected = true;
        public bool Connected {
            get {
                return connected;
            }
            private set {
                if (connected != value) {
                    connected = value;
                    if (!value) {
                        timer.Start();
                    } else if (timer.IsEnabled) {
                        timer.Stop();
                    }
                    RaisePropertyChanged();
                }
            }
        }
        private DispatcherTimer timer;

        private ActiveKodi(string hostname, string port, ConnectionType type) : base(hostname, port, type) {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += Timer_Tick;

            if (type == ConnectionType.Websocket) {
                Connection = new WebSocketHelper();
                Connection.ConnectionClosed += ConnectionClosed;

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
            Connected = false;
        }

        private void Application_OnVolumeChanged(KApplication.Notifications.Data item) {
            if (item.Muted) {
                Muted = true;
            } else {
                Muted = false;
            }
        }

        private static ActiveKodi instance;
        public static ActiveKodi Instance {
            get {
                if (instance == null) {
                    throw new UnauthorizedAccessException("ActiveKodi has to be initialised first");
                }
                return instance;
            }
            private set {
                instance = value;
                KodiChanged?.Invoke(instance, null);
            }
        }
        public static event KodiChangedEventHandler KodiChanged;
        public static async void Init(string hostname, string port, ConnectionType type) {
            Instance = new ActiveKodi(hostname, port, type);
            await Instance.Connect();
        }

        private bool currentlyPlaying;
        public bool CurrentlyPlaying {
            get {
                return currentlyPlaying;
            }
            set {
                currentlyPlaying = value;
                RaisePropertyChanged();
            }
        }

        private bool paused;
        public bool Paused {
            get {
                return paused;
            }
            set {
                paused = value;
                RaisePropertyChanged();
            }
        }
        private bool muted;
        public bool Muted {
            get {
                return muted;
            }
            set {
                muted = value;
                RaisePropertyChanged();
            }
        }

        private void Player_OnStopReceived(KPlayer.Notifications.Stop item) {
            CurrentlyPlaying = false;
            Paused = false;
        }

        private void Player_OnSpeedChangedReceived(KPlayer.Notifications.Data item) {
            if (item.Player.Speed == 0) {
                Paused = true;
            }
        }

        private void Player_OnPlayReceived(KPlayer.Notifications.Data item) {
            CurrentlyPlaying = true;
            Paused = false;
        }

        private void Player_OnPauseReceived(KPlayer.Notifications.Data item) {
            Paused = true;
        }

        private void ConnectionClosed(string message) {
            Connected = false;
        }

        private async void Timer_Tick(object sender, object e) {
            Connected = await Connection.Connect(new Uri("ws://" + Hostname + ":" + Port + "/jsonrpc"));
        }

        public async Task Connect() {
            Connected = await Connection.Connect(new Uri("ws://" + Hostname + ":" + Port + "/jsonrpc"));
        }
    }
    public class Kodi : PropertyChangedBase {
        public string Hostname { get; private set; }
        public string Port { get; private set; }
        public ConnectionType Type { get; private set; }

        public Kodi(string hostname, string port, ConnectionType type) {
            Hostname = hostname;
            Port = port;
            Type = type;
        }

    }
    public enum ConnectionType { Websocket/*, HTTP*/ }
}
