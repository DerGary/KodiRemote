using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.KPlayer.Results;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KPlayer.Params;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IPlayerService {
        #region Notifications
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnPlayReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnPauseReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnSpeedChangedReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Property> OnPropertyChangedReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Seek> OnSeekReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Stop> OnStopReceived;
        #endregion Notifications


        Task<List<Player>> GetActivePlayers();
        Task<ItemResult> GetItem(int playerId, ItemField properties = null);
        Task<Properties> GetProperties(int playerId, PlayerField properties);


        Task<Speed> PlayPause(int playerId, ToggleEnum play);
        Task<Speed> SetSpeed(int playerId, SpeedNumbersEnum speed);
        Task<Speed> SetSpeed(int playerId, IncDecEnum speed);
        Task<bool> Stop(int playerId);
        Task<bool> GoTo(int playerId, ToEnum to);
        Task<bool> GoTo(int playerId, int to);
        Task<Seek> Seek(int playerId, double percentage);
        Task<Seek> Seek(int playerId, Time time);
        Task<Seek> Seek(int playerId, SeekEnum step);


        Task<bool> Move(int playerId, DirectionEnum direction);
        Task<bool> Rotate(int playerId, RotateEnum value);
        Task<bool> Zoom(int playerId, ZoomEnum zoom);
        Task<bool> Zoom(int playerId, ZoomNumbersEnum zoom);


        Task<bool> SetAudioStream(int playerId, int audioStreamID);
        Task<bool> SetAudioStream(int playerId, ToEnum stream);
        Task<bool> SetSubtitle(int playerId, SubtitleEnum subtitle, bool enable = false);
        Task<bool> SetSubtitle(int playerId, int subtitleID, bool enable = false);
        Task<bool> SetPartymode(int playerId, ToggleEnum partymode);
        Task<bool> SetRepeat(int playerId, ExtendRepeatEnum repeat);
        Task<bool> SetShuffle(int playerId, ToggleEnum shuffle);


        //#region openThings
        Task<bool> Open<T>(T item, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null) where T : OpenAble;
        //#endregion openThings
    }
}
