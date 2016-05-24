using KodiRemote.Code.Essentials.Enums;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Notifications;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.JSON.KPlayer.Results;
using KodiRemote.Code.JSON.KPlaylist.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    public class KodiWebSocket : Kodi, IDisposable {
        protected RPCWebSocketHelper Connection { get; set; }
        private Timer timer;

        public KodiWebSocket(KodiSettings settings) : base(settings) {
            Connection = new RPCWebSocketHelper();
            Connection.ConnectionClosed += ConnectionClosed;

            Playlist = new PlaylistWebSocketService(Connection);
            Playlist.OnAdd += Playlist_OnAdd;
            Playlist.OnClear += Playlist_OnClear;
            Playlist.OnRemove += Playlist_OnRemove;
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

        private void Playlist_OnRemove(JSON.KPlaylist.Notifications.OnRemove item) {
            if (item.PlaylistId == PlaylistTypeEnum.Audio.ToInt()) {
                CurrentAudioPlaylist.RemoveAt(item.Position);
            } else if (item.PlaylistId == PlaylistTypeEnum.Video.ToInt()) {
                CurrentVideoPlaylist.RemoveAt(item.Position);
            } //else if (item.PlaylistId == PlaylistTypeEnum.Picture.ToInt()) {
            //    CurrentPicturePlaylist.RemoveAt(item.Position);
            //}
        }

        private void Playlist_OnClear(JSON.KPlaylist.Notifications.OnClear item) {
            if (item.PlaylistId == PlaylistTypeEnum.Audio.ToInt()) {
                CurrentAudioPlaylist.Clear();
            } else if (item.PlaylistId == PlaylistTypeEnum.Video.ToInt()) {
                CurrentVideoPlaylist.Clear();
            } //else if (item.PlaylistId == PlaylistTypeEnum.Picture.ToInt()) {
            //    CurrentPicturePlaylist.Clear();
            //}
        }

        private async void Playlist_OnAdd(JSON.KPlaylist.Notifications.OnAdd item) {
            if (item.PlaylistId == PlaylistTypeEnum.Audio.ToInt()) {
                SongField properties = new SongField();
                properties.Mine();
                CurrentAudioPlaylist.Insert(item.Position, null);
                SongResult song = await AudioLibrary.GetSongDetails(item.Item.Id, properties);
                CurrentAudioPlaylist.Insert(item.Position, song.Song);
            } else if (item.PlaylistId == PlaylistTypeEnum.Video.ToInt()) {
                CurrentVideoPlaylist.Insert(item.Position, null);
                if (item.Item.Type == ItemTypeEnum.Episode.ToString()) {
                    var properties = new EpisodeField();
                    properties.Mine();
                    EpisodeResult episode = await VideoLibrary.GetEpisodeDetails(item.Item.Id, properties);
                    CurrentVideoPlaylist.Add(episode.Episode);
                } else if (item.Item.Type == ItemTypeEnum.Movie.ToString()) {
                    var properties = new MovieField();
                    properties.Mine();
                    MovieResult movie = await VideoLibrary.GetMovieDetails(item.Item.Id, properties);
                    CurrentVideoPlaylist.Add(movie.Movie);
                } else if (item.Item.Type == ItemTypeEnum.Musicvideo.ToString()) {
                    var properties = new MusicVideoField();
                    properties.Mine();
                    MusicVideoResult musicvideo = await VideoLibrary.GetMusicVideoDetails(item.Item.Id, properties);
                    CurrentVideoPlaylist.Add(musicvideo.MusicVideo);
                }
            } //else if (item.PlaylistId == PlaylistTypeEnum.Picture.ToInt()) {
            //    CurrentPicturePlaylist.Insert(item.Position, item.Item);
            //}
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
            Volume = item.Volume;
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

        private void ResetProperties() {
            CurrentAudioPlaylist.Clear();
            CurrentVideoPlaylist.Clear();
            CurrentPicturePlaylist.Clear();
            CurrentlyPlayingItem = null;
            Paused = false;
            Muted = false;
            Volume = 0;
        }

        public override async Task InitProperties() {
            await GetProperties();
        }

        public override async Task Connect() {
            bool result = await Connection.Connect(new Uri("ws://" + Settings.Hostname + ":" + Settings.Port + "/jsonrpc"));
            if (result != Connected) {
                Connected = result;
                if (!Connected) {
                    timer = new Timer(Timer_Tick, null, 0, (int)TimeSpan.FromSeconds(60).TotalMilliseconds);
                } else if (timer != null) {
                    timer.Dispose();
                    timer = null;
                }
            }
        }

        public async Task GetProperties() {
            if (Connected) {
                await InitPlaylists();
                List<Player> players = await Player.GetActivePlayers();
                foreach (Player player in players) {
                    if (player.PlayerId == PlayerTypeEnum.Picture.ToInt()) {
                        continue;
                    }
                    if((await Player.GetProperties(player.PlayerId, PlayerField.WithAll())).Speed == 0) {
                        Paused = true;
                    }
                    ItemResult item = await Player.GetItem(player.PlayerId, ItemField.WithAll());
                    //CurrentlyPlayingItem = item.Item;
                    //Todo:currentlyPlaying Item 
                }
                var appProperties = (await Application.GetProperties(ApplicationField.WithAll()));
                Muted = appProperties.Muted;
                Volume = appProperties.Volume;
            }
        }

        private async Task InitPlaylists() {
            List<Playlist> playlists = await Playlist.GetPlaylists();
            foreach (Playlist list in playlists) {
                ItemsResult items = await Playlist.GetItems(list.PlaylistId);
                if (items.Items != null) {
                    foreach (JSON.General.Results.Item item in items.Items) {
                        if (list.PlaylistId == PlaylistTypeEnum.Audio.ToInt()) {
                            SongResult song = await AudioLibrary.GetSongDetails(item.Id, SongField.WithMine());
                            CurrentAudioPlaylist.Add(song.Song);
                        } else if (list.PlaylistId == PlaylistTypeEnum.Video.ToInt()) {
                            if (item.Type == ItemTypeEnum.Episode.ToString()) {
                                EpisodeResult episode = await VideoLibrary.GetEpisodeDetails(item.Id, EpisodeField.WithMine());
                                CurrentVideoPlaylist.Add(episode.Episode);
                            } else if (item.Type == ItemTypeEnum.Movie.ToString()) {
                                MovieResult movie = await VideoLibrary.GetMovieDetails(item.Id, MovieField.WithMine());
                                CurrentVideoPlaylist.Add(movie.Movie);
                            } else if (item.Type == ItemTypeEnum.Musicvideo.ToString()) {
                                MusicVideoResult musicvideo = await VideoLibrary.GetMusicVideoDetails(item.Id, MusicVideoField.WithMine());
                                CurrentVideoPlaylist.Add(musicvideo.MusicVideo);
                            }
                        } else if (list.PlaylistId == PlaylistTypeEnum.Picture.ToInt()) {
                            CurrentPicturePlaylist.Insert(item.Id, item);
                        }
                    }
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    timer?.Dispose();
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }
                Connection?.Dispose();
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
