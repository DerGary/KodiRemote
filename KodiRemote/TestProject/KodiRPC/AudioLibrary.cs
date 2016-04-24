using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Params;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.KodiRPC {
    [Collection("Kodi")]
    public class AudioLibrary {
        [Fact]
        public async Task Clean() {
            bool result = await Kodi.ActiveInstance.AudioLibrary.Clean();
            Assert.True(result);
        }
        [Fact]
        public async Task Export() {
            bool result = await Kodi.ActiveInstance.AudioLibrary.Export(null);
            Assert.True(result);
        }
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public async Task ExportWithParams(bool overwrite, bool images) {
            bool result = await Kodi.ActiveInstance.AudioLibrary.Export(overwrite, images);
            Assert.True(result);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetAlbumDetails(bool properties) {
            AlbumResult result = await Kodi.ActiveInstance.AudioLibrary.GetAlbumDetails(1, properties ? AlbumField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Album.Label));
        }
        [Theory]
        [InlineData(false, null, false, false)]
        [InlineData(true, 5, true, true)]
        public async Task GetAlbums(bool properties, int? limits, bool sort, bool filter) {
            AlbumsResult result = await Kodi.ActiveInstance.AudioLibrary.GetAlbums(
                properties ? AlbumField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null,
                filter? new KodiRemote.Code.JSON.KAudioLibrary.Filter.AlbumFilter() { GenreId = 1 } : null
            );
            Assert.True(result.Albums.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Albums.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Albums.First().Label));
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetArtistDetails(bool properties) {
            ArtistResult result = await Kodi.ActiveInstance.AudioLibrary.GetArtistDetails(1, properties ? ArtistField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Artist.ArtistName));
            Assert.True(!string.IsNullOrEmpty(result.Artist.Label));
        }
        [Theory]
        [InlineData(false, null, null, false, false)]
        [InlineData(true, true, 5, true, true)]
        public async Task GetArtists(bool properties, bool? albumartistsonly, int? limits, bool sort, bool filter) {
            ArtistsResult result = await Kodi.ActiveInstance.AudioLibrary.GetArtists(
                properties ? ArtistField.WithAll() : null,
                albumartistsonly,
                filter? new KodiRemote.Code.JSON.KAudioLibrary.Filter.ArtistFilter() { GenreId = 1 } : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Artists.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Artists.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Artists.First().ArtistName));
            Assert.True(!string.IsNullOrEmpty(result.Artists.First().Label));
        }
        [Theory]
        [InlineData(false, null, null, false, false)]
        [InlineData(true, true, 5, true, true)]
        public async Task GetGenres(bool properties, bool? albumartistsonly, int? limits, bool sort, bool filter) {
            GenresResult result = await Kodi.ActiveInstance.AudioLibrary.GetGenres(
                properties ? GenreField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Genres.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Genres.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Genres.First().Label));
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyAddedAlbums(bool properties, int? limits, bool sort) {
            AlbumsResult result = await Kodi.ActiveInstance.AudioLibrary.GetRecentlyAddedAlbums(
                properties ? AlbumField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Albums.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Albums.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Albums.First().Label));
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyPlayedAlbums(bool properties, int? limits, bool sort) {
            AlbumsResult result = await Kodi.ActiveInstance.AudioLibrary.GetRecentlyPlayedAlbums(
                properties ? AlbumField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Albums.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Albums.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Albums.First().Label));
        }
        [Theory]
        [InlineData(false, null, null, false)]
        [InlineData(true, 1, 5, true)]
        public async Task GetRecentlyAddedSongs(bool properties, int? albumlimit, int? limits, bool sort) {
            SongsResult result = await Kodi.ActiveInstance.AudioLibrary.GetRecentlyAddedSongs(
                properties ? SongField.WithAll() : null,
                albumlimit,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Songs.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Songs.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Songs.First().Label));
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyPlayedSongs(bool properties, int? limits, bool sort) {
            SongsResult result = await Kodi.ActiveInstance.AudioLibrary.GetRecentlyPlayedSongs(
                properties ? SongField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Songs.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Songs.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Songs.First().Label));
        }
        [Theory]
        [InlineData(false, null, false, false)]
        [InlineData(true, 5, true, true)]
        public async Task GetSongs(bool properties, int? limits, bool sort, bool filter) {
            SongsResult result = await Kodi.ActiveInstance.AudioLibrary.GetSongs(
                properties ? SongField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null,
                filter? new KodiRemote.Code.JSON.KAudioLibrary.Filter.SongFilter() { GenreId = 1 } : null
            );
            Assert.True(result.Songs.Count > 0);
            Assert.True(result.Limits.Start == 0);
            Assert.True(result.Limits.End > 0);
            Assert.True(result.Limits.Total > 0);
            if (limits != null) {
                Assert.True(result.Songs.Count <= limits);
            }
            Assert.True(!string.IsNullOrEmpty(result.Songs.First().Label));
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetSongDetails(bool properties) {
            SongResult result = await Kodi.ActiveInstance.AudioLibrary.GetSongDetails(1, properties ? SongField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Song.Label));
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task Scan(bool directory) {
            bool result = await Kodi.ActiveInstance.AudioLibrary.Scan(directory ? @"D:\Music\Artists": null);
            Assert.True(result);
        }
        [Fact]
        public async Task SetAlbumDetails() {
            bool result = await Kodi.ActiveInstance.AudioLibrary.SetAlbumDetails(new SetAlbumDetails { Description = "bla", AlbumId = 1 });
            Assert.True(result);
        }
        [Fact]
        public async Task SetArtistDetails() {
            bool result = await Kodi.ActiveInstance.AudioLibrary.SetArtistDetails(new SetArtistDetails { Description = "bla", ArtistId = 1 });
            Assert.True(result);
        }
        [Fact]
        public async Task SetSongDetails() {
            bool result = await Kodi.ActiveInstance.AudioLibrary.SetSongDetails(new SetSongDetails { SongId = 1, Comment = "bla" });
            Assert.True(result);
        }
    }
}
