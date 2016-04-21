using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.KPlayer.Results;

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
        Task<Item> GetItem(int playerid, ItemField properties = null);
        Task<Properties> GetProperties(int playerid, PlayerField properties = null);


        Task<bool> PlayPause(int playerID, ToggleEnum play);
        Task<Speed> SetSpeed(int playerID, SpeedNumbersEnum speed);
        Task<Speed> SetSpeed(int playerID, IncDecEnum speed);
        Task<bool> Stop(int playerID);
        Task<bool> GoTo(int playerid, ToEnum to);
        Task<bool> GoTo(int playerid, int to);
        Task<Seek> Seek(int playerID, double percentage);
        Task<Seek> Seek(int playerID, Time time);
        Task<Seek> Seek(int playerID, SeekEnum step);


        Task<bool> Move(int playerid, DirectionEnum direction);
        Task<bool> Rotate(int playerID, RotateEnum value);
        Task<bool> Zoom(int playerID, ZoomEnum zoom);
        Task<bool> Zoom(int playerID, ZoomNumbersEnum zoom);


        Task<bool> SetAudioStream(int playerID, int audioStreamID);
        Task<bool> SetAudioStream(int playerID, ToEnum stream);
        Task<bool> SetSubtitle(int playerID, SubtitleEnum subtitle, bool enable = false);
        Task<bool> SetSubtitle(int playerID, int subtitleID, bool enable = false);
        Task<bool> SetPartymode(int playerID, ToggleEnum partymode);
        Task<bool> SetRepeat(int playerID, ExtendRepeatEnum repeat);
        Task<bool> SetShuffle(int playerID, ToggleEnum shuffle);


        //#region openThings
        Task<bool> OpenPlaylist(int playListID, OptionalRepeatEnum repeat, int position = 0, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenPicture(string path, OptionalRepeatEnum repeat, bool recursive = true, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenMovie(int movieID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenEpisode(int episodeID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenMusicVideo(int musicVideoID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenArtist(int artistID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenAlbum(int albumID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenSong(int songID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenGenre(int genreID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenPartyMode(PartymodeEnum partymode, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenPartyMode(string smartPlayListPath, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        Task<bool> OpenChannel(int channelID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        //#endregion openThings
    }
}
