using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KPlaylist.Params;
using KodiRemote.Code.JSON.KPlaylist.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class Playlist {

        public async Task OpenPicture() {
            bool result = await ActiveKodi.Instance.Player.Open(new KodiRemote.Code.JSON.KPlayer.Params.Picture() { Path = @"D:\Drive\meine Projekte\xbmcremote", Recursive = true }, OptionalRepeatEnum.Null);
            Assert.True(result);
            await Task.Delay(1000);
        }
        [Fact]
        public async Task Clear() {
            await OpenPicture();
            bool result = await ActiveKodi.Instance.Playlist.Clear(2);
            Assert.True(result);
        }
        [Fact]
        public async Task GetItems() {
            await OpenPicture();
            ItemsResult result = await ActiveKodi.Instance.Playlist.GetItems(2);
            Assert.True(result.Items.Count > 0);
        }
        [Fact]
        public async Task GetPlaylists() {
            List<KodiRemote.Code.JSON.KPlaylist.Results.Playlist> result = await ActiveKodi.Instance.Playlist.GetPlaylists();
            Assert.True(result.Count > 0);
        }
        [Fact]
        public async Task GetProperties() {
            await OpenPicture();
            PlaylistProperties result = await ActiveKodi.Instance.Playlist.GetProperties(2, PlaylistField.WithAll());
            Assert.True(result.Size > 0);
        }
        [Fact]//doesnt work
        public async Task InsertRemove() {
            await OpenPicture();
            bool result = await ActiveKodi.Instance.Playlist.Insert(2, 1, new File() { FileValue = @"D:\Drive\meine Projekte\xbmcremote\#08 Film Schauspieler.jpg" });
            Assert.True(result);
            result = await ActiveKodi.Instance.Playlist.Remove(2, 1);
            Assert.True(result);
        }
        [Fact]//doesnt work
        public async Task Swap() {
            await OpenPicture();
            bool result = await ActiveKodi.Instance.Playlist.Swap(2, 1, 2);
            Assert.True(result);
        }
        [Fact]
        public async Task Add() {
            await OpenPicture();
            bool result = await ActiveKodi.Instance.Playlist.Add(2, new File() { FileValue = @"D:\Drive\meine Projekte\xbmcremote\#08 Film Schauspieler.jpg" });
            Assert.True(result);
        }
    }
}
