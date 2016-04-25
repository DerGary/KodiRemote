using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KPlayer.Params;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.KodiRPC {
    [Collection("Kodi")]
    public class Player {
        [Fact]
        public async Task GetActivePlayers() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await Kodi.ActiveInstance.Player.GetActivePlayers();
            Assert.True(result.Count == 1);
            await Stop();
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetItem(bool properties) {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            ItemResult result = await Kodi.ActiveInstance.Player.GetItem(0, properties ? ItemField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Item.Label));
            await Stop();
        }
        [Fact]
        public async Task GetProperties() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            KodiRemote.Code.JSON.KPlayer.Results.Properties result = await Kodi.ActiveInstance.Player.GetProperties(0, PlayerField.WithAll());
            Assert.True(result.CanSeek);
            await Stop();
        }
        //[Fact]doesnt work
        //public async Task GoTo() {
        //    await OpenPicture(1, null, null);
        //    await Task.Delay(1000);
        //    List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await ActiveKodi.Instance.Player.GetActivePlayers();
        //    bool result2 = await ActiveKodi.Instance.Player.GoTo(result.First().PlayerId, 5);
        //    Assert.True(result2);
        //    await Stop();
        //}
        [Fact]
        public async Task GoToEnum() {
            await OpenPicture(1, null, null);
            await Task.Delay(1000);
            List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await Kodi.ActiveInstance.Player.GetActivePlayers();
            bool result2 = await Kodi.ActiveInstance.Player.GoTo(result.First().PlayerId, ToEnum.Next);
            Assert.True(result2);
            result2 = await Kodi.ActiveInstance.Player.GoTo(result.First().PlayerId, ToEnum.Previous);
            Assert.True(result2);
            await Stop();
        }
        [Fact]
        public async Task Move() {
            await OpenPicture(1, null, null);
            await Task.Delay(1000);
            List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await Kodi.ActiveInstance.Player.GetActivePlayers();
            await Kodi.ActiveInstance.Player.Zoom(result.First().PlayerId, ZoomEnum.In);
            bool result2 = await Kodi.ActiveInstance.Player.Move(result.First().PlayerId, DirectionEnum.Left);
            Assert.True(result2);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenMovieTest(int repeat, bool? shuffled, bool? resume) {
            await OpenMovie(repeat, shuffled, resume);
            await Task.Delay(1000);
            await Stop();
        }
        public async Task OpenMovie(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Movie() { MovieId = 2 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenEpisode(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Episode() { EpisodeId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenPlaylistTest(int repeat, bool? shuffled, bool? resume) {
            await OpenPlaylist(repeat, shuffled, resume);
            await Task.Delay(1000);
            await Stop();
        }
        public async Task OpenPlaylist(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new KodiRemote.Code.JSON.KPlayer.Params.Playlist() { PlaylistId = 1, Position = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenPictureTest(int repeat, bool? shuffled, bool? resume) {
            await OpenPicture(repeat, shuffled, resume);
            await Task.Delay(1000);
            await Stop();
        }
        public async Task OpenPicture(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Picture() { Path = @"D:\Drive\meine Projekte\xbmcremote", Recursive = true }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenMusicVideo(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new MusicVideo() { MusicVideoId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }

        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenArtist(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Artist() { ArtistId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenAlbum(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Album() { AlbumId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenSongTest(int repeat, bool? shuffled, bool? resume) {
            await OpenSong(repeat, shuffled, resume);
            await Task.Delay(1000);
            await Stop();
        }
        public async Task OpenSong(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Song() { SongId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenGenre(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new KodiRemote.Code.JSON.KPlayer.Params.Genre() {GenreId = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenPartyMode(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new PartyMode() { PartyModeValue = "music" }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        public async Task OpenChannel(int repeat, bool? shuffled, bool? resume) {
            bool result = await Kodi.ActiveInstance.Player.Open(new Channel() { ChannelId  = 1 }, OptionalRepeatEnum.FromInt(repeat), shuffled, resume);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        public async Task Stop() {
            List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await Kodi.ActiveInstance.Player.GetActivePlayers();
            foreach (var item in result) {
                bool result2 = await Kodi.ActiveInstance.Player.Stop(item.PlayerId);
                Assert.True(result2);
            }
        }
        [Fact]
        public async Task StopTest() {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            await Stop();
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task PlayPause(bool play) {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            KodiRemote.Code.JSON.KPlayer.Results.Speed result = await Kodi.ActiveInstance.Player.PlayPause(1, play ? ToggleEnum.True : ToggleEnum.False);
            if (play) {
                Assert.True(result.CurrentSpeed == 1);
            } else {
                Assert.True(result.CurrentSpeed == 0);
            }
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task PlayPauseToToggle() {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            KodiRemote.Code.JSON.KPlayer.Results.Speed result2 = await Kodi.ActiveInstance.Player.PlayPause(1, ToggleEnum.Toggle);
            Assert.True(result2.CurrentSpeed == 0);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task Rotate() {
            await OpenPicture(1, null, null);
            await Task.Delay(1000);
            List<KodiRemote.Code.JSON.KPlayer.Results.Player> result = await Kodi.ActiveInstance.Player.GetActivePlayers();
            bool result2 = await Kodi.ActiveInstance.Player.Rotate(result.First().PlayerId, RotateEnum.Clockwise);
            Assert.True(result2);
            result2 = await Kodi.ActiveInstance.Player.Rotate(result.First().PlayerId, RotateEnum.CounterClockwise);
            Assert.True(result2);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task Seek() {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            KodiRemote.Code.JSON.KPlayer.Results.Seek result = await Kodi.ActiveInstance.Player.Seek(1, 10);
            Assert.True((int)result.Percentage == 10);
            result = await Kodi.ActiveInstance.Player.Seek(1, new Time(0, 10, 0));
            Assert.True(result.Time.Minutes == 10);
            KodiRemote.Code.JSON.KPlayer.Results.Seek result2 = await Kodi.ActiveInstance.Player.Seek(1, SeekEnum.SmallForward);
            Assert.True(result2.Percentage > result.Percentage);
            KodiRemote.Code.JSON.KPlayer.Results.Seek result3 = await Kodi.ActiveInstance.Player.Seek(1, SeekEnum.BigForward);
            Assert.True(result3.Percentage > result2.Percentage);
            KodiRemote.Code.JSON.KPlayer.Results.Seek result4 = await Kodi.ActiveInstance.Player.Seek(1, SeekEnum.SmallBackward);
            Assert.True(result4.Percentage < result3.Percentage);
            KodiRemote.Code.JSON.KPlayer.Results.Seek result5 = await Kodi.ActiveInstance.Player.Seek(1, SeekEnum.BigBackward);
            Assert.True(result5.Percentage < result4.Percentage);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetAudioStream() {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.SetAudioStream(1, 0);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetAudioStream(1, ToEnum.Next);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetAudioStream(1, ToEnum.Previous);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetPartymode() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.SetPartymode(0, ToggleEnum.True);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetPartymode(0, ToggleEnum.False);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetPartymode(0, ToggleEnum.Toggle);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetRepeat() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.SetRepeat(0, ExtendRepeatEnum.All);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetRepeat(0, ExtendRepeatEnum.Cycle);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetRepeat(0, ExtendRepeatEnum.Off);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetRepeat(0, ExtendRepeatEnum.One);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetShuffle() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.SetShuffle(0, ToggleEnum.True);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetShuffle(0, ToggleEnum.False);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetShuffle(0, ToggleEnum.Toggle);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetSpeed() {
            await OpenSong(1, null, null);
            await Task.Delay(1000);
            KodiRemote.Code.JSON.KPlayer.Results.Speed result = await Kodi.ActiveInstance.Player.SetSpeed(0, SpeedNumbersEnum.thirtytwo);
            Assert.True(result.CurrentSpeed == 32);
            result = await Kodi.ActiveInstance.Player.SetSpeed(0, SpeedNumbersEnum.minusthirtytwo);
            Assert.True(result.CurrentSpeed == -32);
            result = await Kodi.ActiveInstance.Player.SetSpeed(0, SpeedNumbersEnum.zero);
            Assert.True(result.CurrentSpeed == 0);
            result = await Kodi.ActiveInstance.Player.SetSpeed(0, IncDecEnum.Increment);
            Assert.True(result.CurrentSpeed > 0);
            result = await Kodi.ActiveInstance.Player.SetSpeed(0, IncDecEnum.Decrement);
            Assert.True(result.CurrentSpeed == 1);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task SetSubtitle() {
            await OpenMovie(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.SetSubtitle(1, 0, true);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetSubtitle(1, SubtitleEnum.Off, false);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetSubtitle(1, SubtitleEnum.On, false);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetSubtitle(1, SubtitleEnum.Next, false);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.SetSubtitle(1, SubtitleEnum.Previous, false);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
        [Fact]
        public async Task Zoom() {
            await OpenPicture(1, null, null);
            await Task.Delay(1000);
            bool result = await Kodi.ActiveInstance.Player.Zoom(2, ZoomEnum.In);
            Assert.True(result);
            result = await Kodi.ActiveInstance.Player.Zoom(2, ZoomEnum.Out);
            Assert.True(result);
            await Task.Delay(1000);
            await Stop();
        }
    }
}
