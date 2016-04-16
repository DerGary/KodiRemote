
using KodiRemote.Code.JSON.ServiceInterfaces;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KPlayer;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KPlayer.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class PlayerWebSocketService : WebSocketServiceBase, IPlayerService {
        #region Notifications
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnPlayReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnPauseReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Data> OnSpeedChangedReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Property> OnPropertyChangedReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Seek> OnSeekReceived;
        public event ReceivedEventHandler<KPlayer.Notifications.Stop> OnStopReceived;
        #endregion Notifications

        #region events
        public event ReceivedEventHandler<KPlayer.Results.Item> ItemReceived;
        public event ReceivedEventHandler<List<KPlayer.Results.Player>> PlayersReceived;
        public event ReceivedEventHandler<KPlayer.Results.Properties> PropertiesReceived;
        public event ReceivedEventHandler<KPlayer.Results.Speed> SpeedChangedReceived;
        public event ReceivedEventHandler<KPlayer.Results.Seek> SeekReceived;
        public event ReceivedEventHandler<bool> StopReceived;
        public event ReceivedEventHandler<bool> GoToReceived;
        public event ReceivedEventHandler<bool> MoveReceived;
        public event ReceivedEventHandler<bool> RotateReceived;
        public event ReceivedEventHandler<bool> ZoomReceived;
        public event ReceivedEventHandler<bool> SetAudioStreamReceived;
        public event ReceivedEventHandler<bool> SetSubtitleReceived;
        public event ReceivedEventHandler<bool> SetPartymodeReceived;
        public event ReceivedEventHandler<bool> SetRepeatReceived;
        public event ReceivedEventHandler<bool> SetShuffleReceived;
        public event ReceivedEventHandler<bool> OpenPlaylistReceived;
        public event ReceivedEventHandler<bool> OpenPictureReceived;
        public event ReceivedEventHandler<bool> OpenMovieReceived;
        public event ReceivedEventHandler<bool> OpenEpisodeReceived;
        public event ReceivedEventHandler<bool> OpenMusicVideoReceived;
        public event ReceivedEventHandler<bool> OpenArtistReceived;
        public event ReceivedEventHandler<bool> OpenAlbumReceived;
        public event ReceivedEventHandler<bool> OpenSongReceived;
        public event ReceivedEventHandler<bool> OpenGenreReceived;
        public event ReceivedEventHandler<bool> OpenPartyModeReceived;
        public event ReceivedEventHandler<bool> OpenChannelReceived;
        #endregion events

        public PlayerWebSocketService(WebSocketHelper helper) : base(helper) { }



        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == KPlayer.Method.GetItem.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<KPlayer.Results.ItemResult>>(message);
                ItemReceived?.Invoke(item.Result.Item);
            } else if (id == KPlayer.Method.GetActivePlayers.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<KPlayer.Results.Player>>>(message);
                PlayersReceived?.Invoke(item.Result);
            } else if (id == KPlayer.Method.GetProperties.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<KPlayer.Results.Properties>>(message);
                PropertiesReceived?.Invoke(item.Result);
            } else if (id == KPlayer.Method.SetSpeed.ToInt() || id == KPlayer.Method.PlayPause.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<KPlayer.Results.Speed>>(message);
                SpeedChangedReceived?.Invoke(item.Result);
            } else if (id == KPlayer.Method.Seek.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<KPlayer.Results.Seek>>(message);
                SeekReceived?.Invoke(item.Result);
            } else if (id == KPlayer.Method.Stop.ToInt()) {
                ConvertResultToBool(StopReceived, message);
            } else if (id == KPlayer.Method.GoTo.ToInt()) {
                ConvertResultToBool(GoToReceived, message);
            } else if (id == KPlayer.Method.Move.ToInt()) {
                ConvertResultToBool(MoveReceived, message);
            } else if (id == KPlayer.Method.Rotate.ToInt()) {
                ConvertResultToBool(RotateReceived, message);
            } else if (id == KPlayer.Method.Zoom.ToInt()) {
                ConvertResultToBool(ZoomReceived, message);
            } else if (id == KPlayer.Method.SetAudioStream.ToInt()) {
                ConvertResultToBool(SetAudioStreamReceived, message);
            } else if (id == KPlayer.Method.SetSubtitle.ToInt()) {
                ConvertResultToBool(SetSubtitleReceived, message);
            } else if (id == KPlayer.Method.SetPartymode.ToInt()) {
                ConvertResultToBool(SetPartymodeReceived, message);
            } else if (id == KPlayer.Method.SetRepeat.ToInt()) {
                ConvertResultToBool(SetRepeatReceived, message);
            } else if (id == KPlayer.Method.SetShuffle.ToInt()) {
                ConvertResultToBool(SetShuffleReceived, message);
            } else if (id == KPlayer.Method.OpenPlaylist.ToInt()) {
                ConvertResultToBool(OpenPlaylistReceived, message);
            } else if (id == KPlayer.Method.OpenPicture.ToInt()) {
                ConvertResultToBool(OpenPictureReceived, message);
            } else if (id == KPlayer.Method.OpenMovie.ToInt()) {
                ConvertResultToBool(OpenMovieReceived, message);
            } else if (id == KPlayer.Method.OpenEpisode.ToInt()) {
                ConvertResultToBool(OpenEpisodeReceived, message);
            } else if (id == KPlayer.Method.OpenMusicVideo.ToInt()) {
                ConvertResultToBool(OpenMusicVideoReceived, message);
            } else if (id == KPlayer.Method.OpenArtist.ToInt()) {
                ConvertResultToBool(OpenArtistReceived, message);
            } else if (id == KPlayer.Method.OpenAlbum.ToInt()) {
                ConvertResultToBool(OpenAlbumReceived, message);
            } else if (id == KPlayer.Method.OpenSong.ToInt()) {
                ConvertResultToBool(OpenSongReceived, message);
            } else if (id == KPlayer.Method.OpenGenre.ToInt()) {
                ConvertResultToBool(OpenGenreReceived, message);
            } else if (id == KPlayer.Method.OpenPartyMode.ToInt()) {
                ConvertResultToBool(OpenPartyModeReceived, message);
            } else if (id == KPlayer.Method.OpenChannel.ToInt()) {
                ConvertResultToBool(OpenChannelReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == Notification.OnPause.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnPauseReceived?.Invoke(item.Params.Data);
            } else if (method == Notification.OnPlay.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnPlayReceived?.Invoke(item.Params.Data);
            } else if (method == Notification.OnSpeedChanged.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Data>>>(notification);
                OnSpeedChangedReceived?.Invoke(item.Params.Data);
            } else if (method == Notification.OnSeek.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Seek>>>(notification);
                OnSeekReceived?.Invoke(item.Params.Data);
            } else if (method == Notification.OnPropertyChanged.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Property>>>(notification);
                OnPropertyChangedReceived?.Invoke(item.Params.Data);
            } else if (method == Notification.OnStop.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KPlayer.Notifications.Stop>>>(notification);
                OnStopReceived?.Invoke(item.Params.Data);
            }
        }

        public void GetItem(int playerId, ItemField properties = null) {
            if (properties == null) {
                properties = new ItemField();
                properties.All();
            }
            SendRequest(Method.GetItem, new ActivePlayer(playerId, properties));
        }

        public void GetActivePlayers() {
            SendRequest(Method.GetActivePlayers);
        }

        public void GetProperties(int playerId, PlayerField properties = null) {
            if (properties == null) {
                properties = new PlayerField();
                properties.All();
            }
            SendRequest(Method.GetProperties, new ActivePlayer(playerId, properties));
        }

        public void PlayPause(int playerId, ToggleEnum play) {
            SendRequest(Method.PlayPause, new PlayPause(playerId, play));
        }

        private void SetSpeed<T>(int playerId, T value) {
            SendRequest(Method.SetSpeed, new Speed<T>(playerId, value));
        }

        public void SetSpeed(int playerId, SpeedNumbersEnum speed) {
            SetSpeed<int>(playerId, (int)speed);
        }

        public void SetSpeed(int playerId, IncDecEnum speed) {
            SetSpeed<string>(playerId, speed);
        }

        public void Stop(int playerId) {
            SendRequest(Method.Stop, new PlayerID(playerId));
        }

        private void GoTo<T>(int playerId, T value) {
            SendRequest(Method.GoTo, new GoTo<T>(playerId, value));
        }

        public void GoTo(int playerId, ToEnum to) {
            GoTo<string>(playerId, to);
        }

        public void GoTo(int playerId, int to) {
            GoTo<int>(playerId, to);
        }

        private void Seek<T>(int playerId, T value) {
            SendRequest(Method.Seek, new Value<T>(playerId, value));
        }

        public void Seek(int playerId, double percentage) {
            Seek<double>(playerId, percentage);
        }

        public void Seek(int playerId, Time time) {
            Seek<Time>(playerId, time);
        }

        public void Seek(int playerId, SeekEnum step) {
            Seek<string>(playerId, step);
        }

        public void Move(int playerId, DirectionEnum direction) {
            SendRequest(Method.Move, new Direction(playerId, direction));
        }

        public void Rotate(int playerId, RotateEnum value) {
            SendRequest(Method.Rotate, new Value<string>(playerId, value));
        }

        private void Zoom<T>(int playerId, T zoom) {
            SendRequest(Method.Zoom, new Zoom<T>(playerId, zoom));
        }

        public void Zoom(int playerId, ZoomEnum zoom) {
            Zoom<string>(playerId, zoom);
        }

        public void Zoom(int playerId, ZoomNumbersEnum zoom) {
            Zoom<int>(playerId, (int)zoom);
        }

        public void SetAudioStream<T>(int playerId, T audioStream) {
            SendRequest(Method.SetAudioStream, new Stream<T>(playerId, audioStream));
        }

        public void SetAudioStream(int playerId, int audioStreamID) {
            SetAudioStream<int>(playerId, audioStreamID);
        }

        public void SetAudioStream(int playerId, ToEnum stream) {
            SetAudioStream<string>(playerId, stream);
        }

        private void SetSubtitle<T>(int playerId, bool enable, T subtitle) {
            SendRequest(Method.SetSubtitle, new Subtitle<T>(playerId, subtitle, enable));
        }

        public void SetSubtitle(int playerId, SubtitleEnum subtitle, bool enable = false) {
            SetSubtitle<string>(playerId, enable, subtitle);
        }

        public void SetSubtitle(int playerId, int subtitleID, bool enable = false) {
            SetSubtitle<int>(playerId, enable, subtitleID);
        }

        public void SetPartymode(int playerId, ToggleEnum partymode) {
            if (partymode == ToggleEnum.Toggle) {
                SendRequest(Method.SetPartymode, new PartyMode<string>(playerId, partymode));
            } else {
                SendRequest(Method.SetPartymode, new PartyMode<bool>(playerId, partymode));
            }
        }

        public void SetRepeat(int playerId, ExtendRepeatEnum repeat) {
            SendRequest(Method.SetRepeat, new Repeat(playerId, repeat));
        }

        public void SetShuffle(int playerId, ToggleEnum shuffle) {
            if (shuffle == ToggleEnum.Toggle) {
                SendRequest(Method.SetPartymode, new Shuffle<string>(playerId, shuffle));
            } else {
                SendRequest(Method.SetPartymode, new Shuffle<bool>(playerId, shuffle));
            }
        }

        public void OpenPlaylist(int playListID, OptionalRepeatEnum repeat, int position = 0, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Playlist>() {
                Item = new Playlist() { PlaylistId = playListID, Position = position },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenPlaylist, param);
        }

        public void OpenPicture(string path, OptionalRepeatEnum repeat, bool recursive = true, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Picture>() {
                Item = new Picture() { Path = path, Recursive = recursive },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenPicture, param);
        }

        public void OpenMovie(int movieId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Movie>() {
                Item = new Movie() { MovieId = movieId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenMovie, param);
        }

        public void OpenEpisode(int episodeId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Episode>() {
                Item = new Episode() { EpisodeId = episodeId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenEpisode, param);
        }

        public void OpenMusicVideo(int musicVideoId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<MusicVideo>() {
                Item = new MusicVideo() { MusicVideoId = musicVideoId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenMusicVideo, param);
        }

        public void OpenArtist(int artistId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Artist>() {
                Item = new Artist() { ArtistId = artistId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenArtist, param);
        }

        public void OpenAlbum(int albumId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Album>() {
                Item = new Album() { AlbumId = albumId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenAlbum, param);
        }

        public void OpenSong(int songId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Song>() {
                Item = new Song() { SongId = songId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenSong, param);
        }

        public void OpenGenre(int genreId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Genre>() {
                Item = new Genre() { GenreId = genreId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenGenre, param);
        }

        public void OpenPartyMode(PartymodeEnum partymode, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<PartyMode>() {
                Item = new PartyMode() { PartyModeValue = partymode },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenPartyMode, param);
        }

        public void OpenPartyMode(string smartPlayListPath, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<PartyMode>() {
                Item = new PartyMode() { PartyModeValue = smartPlayListPath },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenPartyMode, param);
        }

        public void OpenChannel(int channelId, OptionalRepeatEnum repeat, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null) {
            var param = new Open<Channel>() {
                Item = new Channel() { ChannelId = channelId },
                Options = new Options(shuffled, repeat, resume)
            };
            SendRequest(Method.OpenChannel, param);
        }
    }
}
