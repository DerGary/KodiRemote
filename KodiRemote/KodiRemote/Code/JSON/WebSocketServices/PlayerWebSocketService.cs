﻿
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
using KodiRemote.Code.JSON.KPlayer.Results;

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

        public PlayerWebSocketService(WebSocketHelper helper) : base(helper) { }


        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.GoTo
                || methods[guid] == Method.Move
                || methods[guid] == Method.OpenAlbum
                || methods[guid] == Method.OpenArtist
                || methods[guid] == Method.OpenChannel
                || methods[guid] == Method.OpenEpisode
                || methods[guid] == Method.OpenGenre
                || methods[guid] == Method.OpenMovie
                || methods[guid] == Method.OpenMusicVideo
                || methods[guid] == Method.OpenPartyMode
                || methods[guid] == Method.OpenPicture
                || methods[guid] == Method.OpenPlaylist
                || methods[guid] == Method.OpenSong
                || methods[guid] == Method.Rotate
                || methods[guid] == Method.SetAudioStream
                || methods[guid] == Method.SetPartymode
                || methods[guid] == Method.SetRepeat
                || methods[guid] == Method.SetShuffle
                || methods[guid] == Method.SetSubtitle
                || methods[guid] == Method.Stop
                || methods[guid] == Method.Zoom) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetActivePlayers) {
                DeserializeMessageAndTriggerTask<List<Player>>(guid, message);
            } else if (methods[guid] == Method.GetItem) {
                DeserializeMessageAndTriggerTask<KPlayer.Results.Item>(guid, message);
            } else if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<Properties>(guid, message);
            } else if (methods[guid] == Method.PlayPause) {
                DeserializeMessageAndTriggerTask<Speed>(guid, message);
            } else if (methods[guid] == Method.Seek) {
                DeserializeMessageAndTriggerTask<Seek>(guid, message);
            } else if (methods[guid] == Method.SetSpeed) {
                DeserializeMessageAndTriggerTask<Speed>(guid, message);
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

        public Task<List<Player>> GetActivePlayers() {
            return SendRequest<List<Player>>(Method.GetActivePlayers);
        }

        public Task<KPlayer.Results.Item> GetItem(int playerId, ItemField properties = null) {
            return SendRequest<KPlayer.Results.Item, GetItem>(Method.GetItem, new GetItem { PlayerId = playerId, Properties = properties?.ToList() });
        }

        public Task<Properties> GetProperties(int playerId, PlayerField properties = null) {
            return SendRequest<Properties, GetProperties>(Method.GetProperties, new GetProperties { PlayerId = playerId, Properties = properties?.ToList() });
        }

        public Task<bool> PlayPause(int playerId, ToggleEnum play) {
            return SendRequest<bool, PlayPause>(Method.PlayPause, new PlayPause { PlayerId = playerId, Play = play });
        }

        public Task<Speed> SetSpeed(int playerId, SpeedNumbersEnum speed) {
            return SendRequest<Speed, SetSpeed<int>>(Method.SetSpeed, new SetSpeed<int> { PlayerId = playerId, Speed = (int)speed });
        }

        public Task<Speed> SetSpeed(int playerId, IncDecEnum speed) {
            return SendRequest<Speed, SetSpeed<string>>(Method.SetSpeed, new SetSpeed<string> { PlayerId = playerId, Speed = speed });
        }

        public Task<bool> Stop(int playerId) {
            return SendRequest<bool, Stop>(Method.Stop, new Stop { PlayerId = playerId });
        }

        public Task<bool> GoTo(int playerId, ToEnum to) {
            return SendRequest<bool, GoTo<string>>(Method.GoTo, new GoTo<string> { PlayerId = playerId, To = to });
        }

        public Task<bool> GoTo(int playerId, int to) {
            return SendRequest<bool, GoTo<int>>(Method.GoTo, new GoTo<int> { PlayerId = playerId, To = to });
        }

        public Task<Seek> Seek(int playerId, double percentage) {
            return SendRequest<Seek, Seek<double>>(Method.Seek, new Seek<double> { PlayerId = playerId, Value = percentage });
        }

        public Task<Seek> Seek(int playerId, Time time) {
            return SendRequest<Seek, Seek<Time>>(Method.Seek, new Seek<Time> { PlayerId = playerId, Value = time });
        }

        public Task<Seek> Seek(int playerId, SeekEnum step) {
            return SendRequest<Seek, Seek<string>>(Method.Seek, new Seek<string> { PlayerId = playerId, Value = step });
        }

        public Task<bool> Move(int playerId, DirectionEnum direction) {
            return SendRequest<bool, Move>(Method.Move, new Move { PlayerId = playerId, Direction = direction });
        }

        public Task<bool> Rotate(int playerId, RotateEnum value) {
            return SendRequest<bool, Rotate>(Method.Rotate, new Rotate { PlayerId = playerId, Value = value });
        }

        public Task<bool> Zoom(int playerId, ZoomEnum zoom) {
            return SendRequest<bool, Zoom<string>>(Method.Zoom, new Zoom<string> { PlayerId = playerId, ZoomValue = zoom });
        }

        public Task<bool> Zoom(int playerId, ZoomNumbersEnum zoom) {
            return SendRequest<bool, Zoom<int>>(Method.Zoom, new Zoom<int> { PlayerId = playerId, ZoomValue = (int)zoom });
        }

        public Task<bool> SetAudioStream(int playerId, int audioStreamId) {
            return SendRequest<bool, SetAudioStream<int>>(Method.SetAudioStream, new SetAudioStream<int> { PlayerId = playerId, Stream = audioStreamId });
        }

        public Task<bool> SetAudioStream(int playerId, ToEnum stream) {
            return SendRequest<bool, SetAudioStream<string>>(Method.SetAudioStream, new SetAudioStream<string> { PlayerId = playerId, Stream = stream });
        }

        public Task<bool> SetSubtitle(int playerId, SubtitleEnum subtitle, bool enable = false) {
            return SendRequest<bool, SetSubtitle<string>>(Method.SetSubtitle, new SetSubtitle<string> { PlayerId = playerId, Subtitle = subtitle, Enable = enable });
        }

        public Task<bool> SetSubtitle(int playerId, int subtitleId, bool enable = false) {
            return SendRequest<bool, SetSubtitle<int>>(Method.SetSubtitle, new SetSubtitle<int> { PlayerId = playerId, Subtitle = subtitleId, Enable = enable });
        }

        public Task<bool> SetPartymode(int playerId, ToggleEnum partymode) {
            if (partymode == ToggleEnum.Toggle) {
                return SendRequest<bool, SetPartymode<string>>(Method.SetPartymode, new SetPartymode<string> { PlayerId = playerId, PartyMode = partymode });
            } else {
                return SendRequest<bool, SetPartymode<bool>>(Method.SetPartymode, new SetPartymode<bool> { PlayerId = playerId, PartyMode = partymode });
            }
        }

        public Task<bool> SetRepeat(int playerId, ExtendRepeatEnum repeat) {
            return SendRequest<bool, SetRepeat>(Method.SetRepeat, new SetRepeat { PlayerId = playerId, Repeat = repeat });
        }

        public Task<bool> SetShuffle(int playerId, ToggleEnum shuffle) {
            if (shuffle == ToggleEnum.Toggle) {
                return SendRequest<bool, SetShuffle<string>>(Method.SetShuffle, new SetShuffle<string> { PlayerId = playerId, Shuffle = shuffle });
            } else {
                return SendRequest<bool, SetShuffle<bool>>(Method.SetShuffle, new SetShuffle<bool> { PlayerId = playerId, Shuffle = shuffle });
            }
        }

        private Task<bool> Open<T>(Method method, T item, Options options) where T : KPlayer.Params.Item {
            var param = new Open<T>() {
                Item = item,
                Options = options
            };
            return SendRequest<bool, Open<T>>(method, param);
        }

        public Task<bool> OpenPlaylist(int playListId, OptionalRepeatEnum repeat, int position = 0, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenPlaylist, new Playlist { PlaylistId = playListId, Position = position }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenPicture(string path, OptionalRepeatEnum repeat, bool recursive = true, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenPicture, new Picture { Path = path, Recursive = recursive }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenMovie(int movieId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenMovie, new Movie { MovieId = movieId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenEpisode(int episodeId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenEpisode, new Episode { EpisodeId = episodeId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenMusicVideo(int musicVideoId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenMusicVideo, new MusicVideo { MusicVideoId = musicVideoId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenArtist(int artistId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenArtist, new Artist { ArtistId = artistId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenAlbum(int albumId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenAlbum, new Album { AlbumId = albumId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenSong(int songId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenSong, new Song { SongId = songId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenGenre(int genreId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenGenre, new Genre { GenreId = genreId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenPartyMode(PartymodeEnum partymode, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenPartyMode, new PartyMode { PartyModeValue = partymode }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenPartyMode(string smartPlayListPath, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenPartyMode, new PartyMode { PartyModeValue = smartPlayListPath }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }

        public Task<bool> OpenChannel(int channelId, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) {
            return Open(Method.OpenChannel, new Channel { ChannelId = channelId }, new Options { Repeat = repeat, Resume = resume, Shuffled = shuffled });
        }
    }
}
