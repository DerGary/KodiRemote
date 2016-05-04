using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.General.Notifications;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.JSON.ServiceInterfaces;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace KodiRemote.Code.Essentials {

    public abstract class Kodi : PropertyChangedBase, IDisposable {
        protected KodiSettings settings;

        public IPlayerService Player { get; protected set; }
        public IInputService Input { get; protected set; }
        public IApplicationService Application { get; protected set; }
        public IGUIService GUI { get; protected set; }
        public ISystemService System { get; protected set; }
        public IAddonsService Addons { get; protected set; }
        public IFilesService Files { get; protected set; }
        public IJSONRPCService JSONRPC { get; protected set; }
        public IPVRService PVR { get; protected set; }
        public IVideoLibraryService VideoLibrary { get; protected set; }
        public IAudioLibraryService AudioLibrary { get; protected set; }
        public IPlaylistService Playlist { get; protected set; }
        public abstract bool Muted { get; protected set; }
        public abstract double Volume { get; protected set; }
        public abstract bool Paused { get; protected set; }
        public abstract Item CurrentlyPlayingItem { get; protected set; }
        public abstract bool Connected { get; protected set; }
        public DatabaseConnection Database { get; protected set; }


        public abstract ObservableCollection<Song> CurrentAudioPlaylist { get; protected set; }
        public abstract ObservableCollection<object> CurrentVideoPlaylist { get; protected set; }
        public abstract ObservableCollection<object> CurrentPicturePlaylist { get; protected set; }

        private static Kodi instance;
        public static Kodi ActiveInstance {
            get {
                return instance;
            }
            private set {
                instance = value;
                KodiChanged?.Invoke(instance, null);
            }
        }

        protected Kodi(KodiSettings settings) {
            this.settings = settings;
            this.Database = new DatabaseConnection();
        }

        public static event KodiChangedEventHandler KodiChanged;
        public static async Task Init(KodiSettings settings) {
            if (settings.Type == ConnectionType.Websocket) {
                ActiveInstance = new KodiWebSocket(settings);
            }
            await ActiveInstance.Init();
        }

        public abstract Task Init();
        public abstract Task Connect();
        public abstract void Dispose();
    }

}
