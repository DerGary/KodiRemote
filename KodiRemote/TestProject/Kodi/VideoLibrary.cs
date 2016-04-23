using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class VideoLibrary {
        [Fact]
        public async Task Clean() {
            bool result = await ActiveKodi.Instance.VideoLibrary.Clean();
            Assert.True(result);
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Export(bool path) {
            bool result = await ActiveKodi.Instance.VideoLibrary.Export(path? "C:/":null);
            Assert.True(result);
        }
        [Theory]
        [InlineData(false, false, false)]
        [InlineData(true, true, true)]
        public async Task Export2(bool overwrite, bool actorthumbs, bool images) {
            bool result = await ActiveKodi.Instance.VideoLibrary.Export(overwrite, actorthumbs, images);
            Assert.True(result);
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetEpisodeDetails(bool properties) {
            EpisodeResult result = await ActiveKodi.Instance.VideoLibrary.GetEpisodeDetails(1, properties ? EpisodeField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Episode.Label));
        }
        [Theory]
        [InlineData(false, null, null, null, false)]
        [InlineData(true, 1, 1, 5, true)]
        public async Task GetEpisodes(bool properties, int? tvShowId, int? season, int? limits, bool sort) {
            EpisodesResult result = await ActiveKodi.Instance.VideoLibrary.GetEpisodes(properties ? EpisodeField.WithAll() : null, tvShowId, season, limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null, sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.Episodes.Count > 0);
        }
        [Theory]
        [InlineData(1, false, null, false)]
        [InlineData(2, true, 5, true)]
        [InlineData(3, true, 5, true)]
        public async Task GetGenres(int type, bool properties, int? limits, bool sort) {
            GenresResult result = await ActiveKodi.Instance.VideoLibrary.GetGenres(TypeEnum.FromInt(type),properties ? GenreField.WithAll() : null, limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null, sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.Genres.Count > 0);
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetMovieDetails(bool properties) {
            MovieResult result = await ActiveKodi.Instance.VideoLibrary.GetMovieDetails(1 ,properties ? MovieField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Movie.Label));
        }
        [Theory]
        [InlineData(false, null, false, false)]
        [InlineData(true, 5, true, true)]
        public async Task GetMovies(bool properties, int? limits, bool sort, bool filter) {
            MoviesResult result = await ActiveKodi.Instance.VideoLibrary.GetMovies(
                properties ? MovieField.WithAll() : null,
                filter ? new MovieFilter() { GenreId = 2 } : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.Movies.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetMovieSetDetails(bool properties, int? limits, bool sort) {
            MovieSetDetailsResult result = await ActiveKodi.Instance.VideoLibrary.GetMovieSetDetails(
                1,
                properties ? MovieSetField.WithAll() : null,
                properties ? MovieField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(!string.IsNullOrEmpty(result.MovieSet.Label));
            Assert.True(result.MovieSet.Movies.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetMovieSets(bool properties, int? limits, bool sort) {
            MovieSetsResult result = await ActiveKodi.Instance.VideoLibrary.GetMovieSets(
                properties ? MovieSetField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.MovieSets.Count > 0);
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetMusicVideoDetails(bool properties) {
            MusicVideoResult result = await ActiveKodi.Instance.VideoLibrary.GetMusicVideoDetails(
                1,
                properties ? MusicVideoField.WithAll() : null
            );
            Assert.True(!string.IsNullOrEmpty(result.MusicVideo.Label));
        }
        [Theory]
        [InlineData(false, null, false, false)]
        [InlineData(true, 5, true, true)]
        public async Task GetMusicVideos(bool properties, int? limits, bool sort, bool filter) {
            MusicVideosResult result = await ActiveKodi.Instance.VideoLibrary.GetMusicVideos(
                properties ? MusicVideoField.WithAll() : null,
                filter ? new MusicVideoFilter() { GenreId = 29 } : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null
            );
            Assert.True(result.MusicVideos.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyAddedEpisodes(bool properties, int? limits, bool sort) {
            EpisodesResult result = await ActiveKodi.Instance.VideoLibrary.GetRecentlyAddedEpisodes(
                properties ? EpisodeField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null,
                sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.Episodes.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyAddedMovies(bool properties, int? limits, bool sort) {
            MoviesResult result = await ActiveKodi.Instance.VideoLibrary.GetRecentlyAddedMovies(
                properties ? MovieField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null,
                sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.Movies.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetRecentlyAddedMusicVideos(bool properties, int? limits, bool sort) {
            MusicVideosResult result = await ActiveKodi.Instance.VideoLibrary.GetRecentlyAddedMusicVideos(
                properties ? MusicVideoField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null,
                sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.MusicVideos.Count > 0);
        }
        [Theory]
        [InlineData(false, null, false)]
        [InlineData(true, 5, true)]
        public async Task GetSeasons(bool properties, int? limits, bool sort) {
            TVShowSeasonsResult result = await ActiveKodi.Instance.VideoLibrary.GetSeasons(
                1,
                properties ? SeasonField.WithAll() : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null,
                sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.TVShowSeasons.Count > 0);
        }
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task GetTVShowDetails(bool properties) {
            TVShowResult result = await ActiveKodi.Instance.VideoLibrary.GetTVShowDetails(
                1,
                properties ? TVShowField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.TVShow.Label));
        }
        [Theory]
        [InlineData(false, null, false, false)]
        [InlineData(true, 5, true, true)]
        public async Task GetTVShows(bool properties, int? limits, bool sort, bool filter) {
            TVShowsResult result = await ActiveKodi.Instance.VideoLibrary.GetTVShows(
                properties ? TVShowField.WithAll() : null,
                filter ? new TVShowFilter() { GenreId = 1 } : null,
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits) : null,
                sort? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            Assert.True(result.TVShows.Count > 0);
        }
        [Fact]
        public async Task RemoveEpisode() {
            bool result = await ActiveKodi.Instance.VideoLibrary.RemoveEpisode(2);
            Assert.True(result);
        }
        [Fact]
        public async Task RemoveMovie() {
            bool result = await ActiveKodi.Instance.VideoLibrary.RemoveMovie(2);
            Assert.True(result);
        }
        [Fact]
        public async Task RemoveMusicVideo() {
            bool result = await ActiveKodi.Instance.VideoLibrary.RemoveMusicVideo(1);
            Assert.True(result);
        }
        [Fact]
        public async Task RemoveTVShow() {
            bool result = await ActiveKodi.Instance.VideoLibrary.RemoveTVShow(1);
            Assert.True(result);
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Scan(bool directory) {
            bool result = await ActiveKodi.Instance.VideoLibrary.Scan(directory ? @"Q:\" : null );
            Assert.True(result);
        }
        [Fact]
        public async Task SetEpisodeDetails() {
            bool result = await ActiveKodi.Instance.VideoLibrary.SetEpisodeDetails(
                new KodiRemote.Code.JSON.KVideoLibrary.Params.SetEpisodeDetails {
                    EpisodeId = 1,
                    Plot = "blabla"
                });
            Assert.True(result);
        }
        [Fact]
        public async Task SetMovieDetails() {
            bool result = await ActiveKodi.Instance.VideoLibrary.SetMovieDetails(
                new KodiRemote.Code.JSON.KVideoLibrary.Params.SetMovieDetails {
                    MovieId = 1,
                    Plot = "blabla"
                });
            Assert.True(result);
        }
        [Fact]
        public async Task SetMusicVideoDetails() {
            bool result = await ActiveKodi.Instance.VideoLibrary.SetMusicVideoDetails(
                new KodiRemote.Code.JSON.KVideoLibrary.Params.SetMusicVideoDetails {
                    MusicVideoId = 1,
                    Plot = "blabla"
                });
            Assert.True(result);
        }
        [Fact]
        public async Task SetTVShowDetails() {
            bool result = await ActiveKodi.Instance.VideoLibrary.SetTVShowDetails(
                new KodiRemote.Code.JSON.KVideoLibrary.Params.SetTVShowDetails {
                    TVShowId = 1,
                    Plot = "blabla"
                });
            Assert.True(result);
        }
    }
}
