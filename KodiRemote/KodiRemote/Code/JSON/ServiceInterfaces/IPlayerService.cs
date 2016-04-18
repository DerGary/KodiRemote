using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        event ReceivedEventHandler<List<KPlayer.Results.Player>> PlayersReceived;
        event ReceivedEventHandler<KPlayer.Results.Item> ItemReceived;
        event ReceivedEventHandler<KPlayer.Results.Properties> PropertiesReceived;
        void GetActivePlayers();
        void GetItem(int playerid, ItemField properties = null);
        void GetProperties(int playerid, PlayerField properties = null);


        event ReceivedEventHandler<KPlayer.Results.Speed> SpeedChangedReceived;
        event ReceivedEventHandler<KPlayer.Results.Seek> SeekReceived;
        event ReceivedEventHandler<bool> StopReceived;
        event ReceivedEventHandler<bool> GoToReceived;
        void PlayPause(int playerID, ToggleEnum play);
        void SetSpeed(int playerID, SpeedNumbersEnum speed);
        void SetSpeed(int playerID, IncDecEnum speed);
        void Stop(int playerID);
        void GoTo(int playerid, ToEnum to);
        void GoTo(int playerid, int to);
        void Seek(int playerID, double percentage);
        void Seek(int playerID, Time time);
        void Seek(int playerID, SeekEnum step);


        event ReceivedEventHandler<bool> MoveReceived;
        event ReceivedEventHandler<bool> RotateReceived;
        event ReceivedEventHandler<bool> ZoomReceived;
        void Move(int playerid, DirectionEnum direction);
        void Rotate(int playerID, RotateEnum value);
        void Zoom(int playerID, ZoomEnum zoom);
        void Zoom(int playerID, ZoomNumbersEnum zoom);


        event ReceivedEventHandler<bool> SetAudioStreamReceived;
        event ReceivedEventHandler<bool> SetSubtitleReceived;
        event ReceivedEventHandler<bool> SetPartymodeReceived;
        event ReceivedEventHandler<bool> SetRepeatReceived;
        event ReceivedEventHandler<bool> SetShuffleReceived;
        void SetAudioStream(int playerID, int audioStreamID);
        void SetAudioStream(int playerID, ToEnum stream);
        void SetSubtitle(int playerID, SubtitleEnum subtitle, bool enable = false);
        void SetSubtitle(int playerID, int subtitleID, bool enable = false);
        void SetPartymode(int playerID, ToggleEnum partymode);
        void SetRepeat(int playerID, ExtendRepeatEnum repeat);
        void SetShuffle(int playerID, ToggleEnum shuffle);


        //#region openThings
        event ReceivedEventHandler<bool> OpenPlaylistReceived;
        event ReceivedEventHandler<bool> OpenPictureReceived;
        event ReceivedEventHandler<bool> OpenMovieReceived;
        event ReceivedEventHandler<bool> OpenEpisodeReceived;
        event ReceivedEventHandler<bool> OpenMusicVideoReceived;
        event ReceivedEventHandler<bool> OpenArtistReceived;
        event ReceivedEventHandler<bool> OpenAlbumReceived;
        event ReceivedEventHandler<bool> OpenSongReceived;
        event ReceivedEventHandler<bool> OpenGenreReceived;
        event ReceivedEventHandler<bool> OpenPartyModeReceived;
        event ReceivedEventHandler<bool> OpenChannelReceived;
        void OpenPlaylist(int playListID, OptionalRepeatEnum repeat, int position = 0, bool? shuffled = null, bool? resume = null);
        void OpenPicture(string path, OptionalRepeatEnum repeat, bool recursive = true, bool? shuffled = null, bool? resume = null);
        void OpenMovie(int movieID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenEpisode(int episodeID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenMusicVideo(int musicVideoID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenArtist(int artistID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenAlbum(int albumID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenSong(int songID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenGenre(int genreID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenPartyMode(PartymodeEnum partymode, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenPartyMode(string smartPlayListPath, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        void OpenChannel(int channelID, OptionalRepeatEnum repeat, bool? shuffled = null, bool? resume = null);
        //#endregion openThings
    }
}
