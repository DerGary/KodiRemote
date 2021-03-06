﻿using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KApplication.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.JSON.KGUI.Results;
using KodiRemote.Code.JSON.KJSONRPC.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    [Table("Kodis")]
    public class KodiSettings : PropertyChangedBase {
        private string name;
        [Key]
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
        private string username;
        public string Username {
            get {
                return username;
            }
            set {
                username = value;
                RaisePropertyChanged();
            }
        }
        private string password;
        public string Password {
            get {
                return password;
            }
            set {
                password = value;
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
        [NotMapped]
        public string HttpUrl {
            get {
                return "http://" + Hostname + ":" + Port + "/jsonrpc";
            }
        }

        private string websocketPort;
        public string WebsocketPort {
            get {
                return websocketPort;
            }
            set {
                websocketPort = value;
                RaisePropertyChanged();
            }
        }
        private ConnectionType type;
        public ConnectionType Type {
            get {
                return type;
            }
            set {
                if (type != value) {
                    type = value;
                    RaisePropertyChanged();
                }
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
        ~KodiSettings() {
            if (Kodi != null)
                Kodi.PropertyChanged -= Kodi_PropertyChanged;
        }

        private bool online;
        [NotMapped]
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
                RaisePropertyChanged(nameof(JSONVersion));
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
                RaisePropertyChanged(nameof(JSONVersion));
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
                RaisePropertyChanged(nameof(JSONVersion));
            }
        }
        [NotMapped]
        public string JSONVersion {
            get {
                return JSONMajor + "." + JSONMinor + "." + JSONPatch;
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
                RaisePropertyChanged(nameof(KodiVersion));
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
                RaisePropertyChanged(nameof(KodiVersion));
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
                RaisePropertyChanged(nameof(KodiVersion));
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
                RaisePropertyChanged(nameof(KodiVersion));
            }
        }
        [NotMapped]
        public string KodiVersion {
            get {
                return KodiMajor + "." + KodiMinor + "." + KodiRevision + "." + KodiTag;
            }
        }
        private bool muted;
        [NotMapped]
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
        [NotMapped]
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

        //Library Count
        private int tvShowCount;
        public int TVShowCount {
            get {
                return tvShowCount;
            }
            set {
                tvShowCount = value;
                RaisePropertyChanged();
            }
        }
        private int movieCount;
        public int MovieCount {
            get {
                return movieCount;
            }
            set {
                movieCount = value;
                RaisePropertyChanged();
            }
        }
        private int episodeCount;
        public int EpisodeCount {
            get {
                return episodeCount;
            }
            set {
                episodeCount = value;
                RaisePropertyChanged();
            }
        }

        private int movieSetCount;
        public int MovieSetCount {
            get {
                return movieSetCount;
            }
            set {
                movieSetCount = value;
                RaisePropertyChanged();
            }
        }
        private int albumCount;
        public int AlbumCount {
            get {
                return albumCount;
            }
            set {
                albumCount = value;
                RaisePropertyChanged();
            }
        }
        private int songCount;
        public int SongCount {
            get {
                return songCount;
            }
            set {
                songCount = value;
                RaisePropertyChanged();
            }
        }
        private int artistCount;
        public int ArtistCount {
            get {
                return artistCount;
            }
            set {
                artistCount = value;
                RaisePropertyChanged();
            }
        }
        private int musicVideoCount;
        public int MusicVideoCount {
            get {
                return musicVideoCount;
            }
            set {
                musicVideoCount = value;
                RaisePropertyChanged();
            }
        }




        private Kodi Kodi;
        private async Task InitConnection() {
            if (Kodi == null) {
                if(Active) {
                    Kodi = Kodi.ActiveInstance;
                }else {
                    Kodi = new KodiWebSocket(this);
                }
                await Kodi.Connect();
                await Kodi.DatabaseInit();
                Kodi.PropertyChanged += Kodi_PropertyChanged;
            }
            Online = Kodi.Connected;
        }

        public async Task UpdateDatabase() {
            await Kodi.StartDatabaseUpdate();
        }

        public async Task CheckOnlineStatus() {
            await InitConnection();
        }

        private bool getInfo = false;

        public async Task TriggerGetInfo() {
            await InitConnection();
            getInfo = true;
            await GetInfo();
        }

        public async Task GetInfo() {
            if (Online) {
                JSONRPCVersion jsonVersion = await Kodi.JSONRPC.Version();
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
                TVShowsResult result = await Kodi.VideoLibrary.GetTVShows(limits: new JSON.General.Limits(0, 1));
                TVShowCount = result.Limits.Total;
                MoviesResult mresult = await Kodi.VideoLibrary.GetMovies(limits: new JSON.General.Limits(0, 1));
                MovieCount = mresult.Limits.Total;
                EpisodesResult eresult = await Kodi.VideoLibrary.GetEpisodes(limits: new JSON.General.Limits(0, 1));
                EpisodeCount = eresult.Limits.Total;
                MovieSetsResult msresult = await Kodi.VideoLibrary.GetMovieSets(limits: new JSON.General.Limits(0, 1));
                MovieSetCount = msresult.Limits.Total;
                MusicVideosResult mvresult = await Kodi.VideoLibrary.GetMusicVideos(limits: new JSON.General.Limits(0, 1));
                MusicVideoCount = mvresult.Limits.Total;
                AlbumsResult aresult = await Kodi.AudioLibrary.GetAlbums(limits: new JSON.General.Limits(0, 1));
                AlbumCount = aresult.Limits.Total;
                SongsResult sresult = await Kodi.AudioLibrary.GetSongs(limits: new JSON.General.Limits(0, 1));
                SongCount = sresult.Limits.Total;
                ArtistsResult arresult = await Kodi.AudioLibrary.GetArtists(limits: new JSON.General.Limits(0, 1));
                ArtistCount = arresult.Limits.Total;
                await SettingsDatabase.Instance.InsertOrUpdateKodi(this);
            }
            getInfo = false;
        }

        private async void Kodi_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "Muted") {
                Muted = Kodi.Muted;
            } else if (e.PropertyName == "Volume") {
                Volume = Kodi.Volume;
            } else if (e.PropertyName == "Connected") {
                Online = Kodi.Connected;
                if (getInfo) {
                    await GetInfo();
                }
            }
        }

        public override bool Equals(object obj) {
            var other = obj as KodiSettings;
            if (other == null) {
                return false;
            }
            return other.Name == Name;
        }
    }
}
