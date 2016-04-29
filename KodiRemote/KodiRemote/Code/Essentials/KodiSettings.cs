using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KApplication.Results;
using KodiRemote.Code.JSON.KGUI.Results;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    [Table("Kodis")]
    public class KodiSettings : PropertyChangedBase {
        private string name;
        [PrimaryKey]
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                RaisePropertyChanged();
            }
        }
        private string hostname;
        public string Hostname {
            get {
                return hostname;
            }
            set {
                hostname = value;
                RaisePropertyChanged();
            }
        }
        private string port;
        public string Port {
            get {
                return port;
            }
            set {
                port = value;
                RaisePropertyChanged();
            }
        }
        private ConnectionType type;
        public ConnectionType Type {
            get {
                return type;
            }
            set {
                type = value;
                RaisePropertyChanged();
            }
        }
        private bool active;
        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
                RaisePropertyChanged();
            }
        }

        public KodiSettings() { }
        public KodiSettings(string name, string hostname, string port, ConnectionType type, bool active) : this() {
            Name = name;
            Hostname = hostname;
            Port = port;
            Type = type;
            Active = active;
        }

        private bool online;
        [Ignore]
        public bool Online {
            get {
                return online;
            }
            set {
                online = value;
                RaisePropertyChanged();
            }
        }
        private int jsonMajor;
        public int JSONMajor {
            get {
                return jsonMajor;
            }
            set {
                jsonMajor = value;
                RaisePropertyChanged();
            }
        }
        private int jsonMinor;
        public int JSONMinor {
            get {
                return jsonMinor;
            }
            set {
                jsonMinor = value;
                RaisePropertyChanged();
            }
        }
        private int jsonPatch;
        public int JSONPatch {
            get {
                return jsonPatch;
            }
            set {
                jsonPatch = value;
                RaisePropertyChanged();
            }
        }
        private string kodiName;
        public string KodiName {
            get {
                return kodiName;
            }
            set {
                kodiName = value;
                RaisePropertyChanged();
            }
        }
        private int kodiMajor;
        public int KodiMajor {
            get {
                return kodiMajor;
            }
            set {
                kodiMajor = value;
                RaisePropertyChanged();
            }
        }
        private int kodiMinor;
        public int KodiMinor {
            get {
                return kodiMinor;
            }
            set {
                kodiMinor = value;
                RaisePropertyChanged();
            }
        }
        private string kodiRevision;
        public string KodiRevision {
            get {
                return kodiRevision;
            }
            set {
                kodiRevision = value;
                RaisePropertyChanged();
            }
        }
        private string kodiTag;
        public string KodiTag {
            get {
                return kodiTag;
            }
            set {
                kodiTag = value;
                RaisePropertyChanged();
            }
        }

        private bool muted;
        [Ignore]
        public bool Muted {
            get {
                return muted;
            }
            set {
                muted = value;
                RaisePropertyChanged();
            }
        }
        private double volume;
        [Ignore]
        public double Volume {
            get {
                return volume;
            }
            set {
                volume = value;
                RaisePropertyChanged();
            }
        }
        private string skinName;
        public string SkinName {
            get {
                return skinName;
            }
            set {
                skinName = value;
                RaisePropertyChanged();
            }
        }



        private Kodi Kodi;

        public async Task GetInfo() {
            Kodi = new KodiWebSocket(this);
            await Kodi.Connect();
            Online = Kodi.Connected;
            if (Online) {
                Kodi.PropertyChanged += Kodi_PropertyChanged;
                JSON.KJSONRPC.Results.Version jsonVersion = await Kodi.JSONRPC.Version();
                JSONMajor = jsonVersion.VersionValue.Major;
                JSONMinor = jsonVersion.VersionValue.Minor;
                JSONPatch = jsonVersion.VersionValue.Patch;
                ApplicationProperties properties = await Kodi.Application.GetProperties(ApplicationField.WithAll());
                Muted = properties.Muted;
                KodiMajor = properties.Version.Major;
                KodiMinor = properties.Version.Minor;
                KodiRevision = properties.Version.Revision;
                KodiTag = properties.Version.Tag;
                Volume = properties.Volume;
                KodiName = properties.Name;
                GUIProperties guiProps = await Kodi.GUI.GetProperties(GUIField.WithAll());
                SkinName = guiProps.Skin.Name;
                await SettingsDatabase.Instance.InsertOrUpdateKodi(this);
                //todo: Library Counts
            }
        }

        private void Kodi_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "Muted") {
                Muted = Kodi.Muted;
            } else if (e.PropertyName == "Volume") {
                Volume = Kodi.Volume;
            }
        }
    }
}
