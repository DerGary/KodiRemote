using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KPlayer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IPlayerService {
        void GetActivePlayers();
        void GetItem(int playerid, ItemField properties = null);
        void GetProperties(int playerid, PlayerField properties = null);

        event ReceivedEventHandler<Item> ItemReceived;
        event ReceivedEventHandler<List<Player>> PlayersReceived;
        event ReceivedEventHandler<PlayerProperties> PropertiesReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnPlayReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnPauseReceived;
        event ReceivedEventHandler<KPlayer.Notifications.Data> OnSpeedChangedReceived;
        //Task<Speed> PlayPause(int playerID, ToggleEnum play = ToggleEnum.Toggle);
        //Task<bool> Stop(int playerID);
        //Task<bool> GoTo(int playerid, ToEnum to);
        //Task<bool> GoTo(int playerid, int to);
        //Task<Seek> Seek(int playerID, double percentage);
        //Task<Seek> Seek(int playerID, Time time);
        //Task<Seek> Seek(int playerID, SeekEnum step);
        //Task<Speed> SetSpeed(int playerID, SpeedNumbersEnum speed);
        //Task<Speed> SetSpeed(int playerID, IncDecEnum speed);


        //Task<bool> Move(int playerid, DirectionEnum direction);
        //Task<bool> Rotate(int playerID, RotateEnum value = RotateEnum.clockwise);
        //Task<bool> Zoom(int playerID, ZoomEnum zoom);
        //Task<bool> Zoom(int playerID, ZoomNumbersEnum zoom);

        //Task<bool> SetAudioStream(int playerID, int audioStreamID);
        //Task<bool> SetAudioStream(int playerID, ToEnum stream);
        //Task<bool> SetSubtitle(int playerID, SubtitleEnum subtitle, bool enable = false);
        //Task<bool> SetSubtitle(int playerID, int subtitleID, bool enable = false);
        //Task<bool> SetPartymode(int playerID, ToggleEnum partymode);
        //Task<bool> SetRepeat(int playerID, ExtendRepeatEnum repeat);
        //Task<bool> SetShuffle(int playerID, ToggleEnum shuffle);

        //#region openThings
        //Task<bool> OpenPlaylist(int playListID, int position = 0, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenPicture(string path, bool recursive = true, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenMovie(int movieID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenEpisode(int episodeID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenMusicVideo(int musicVideoID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenArtist(int artistID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenAlbum(int albumID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenSong(int songID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenGenre(int genreID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenPartyMode(PartymodeEnum partymode = PartymodeEnum.music, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenPartyMode(String smartPlayListPath, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //Task<bool> OpenChannel(int channelID, OptionalBooleanEnum shuffled = OptionalBooleanEnum.Null, RepeatEnum repeat = RepeatEnum.Null, OptionalBooleanEnum resume = OptionalBooleanEnum.Null);
        //#endregion openThings
    }
}
