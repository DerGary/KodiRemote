using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.JSON.KAddons.Results;
using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.Common;
using Microsoft.EntityFrameworkCore;

namespace KodiRemote.Code.Database {
    public class DatabaseOperations {
        private DatabaseContextWrapper database;

        public DatabaseOperations(string name) {
            this.database = new DatabaseContextWrapper(name);
        }

        public async Task Init() {
            await database.Init();
        }


        #region SaveLogic
        public async Task SaveTVShows(List<TVShow> tvshows) {
            var saved = await database.TVShows.GetDataAsync();
            foreach (TVShow tvshow in tvshows) {
                Debug.WriteLine("Save TVShow with id: " + tvshow.TVShowId);
                var tvshowentry = new TVShowTableEntry(tvshow);
                saved.Remove(tvshowentry.Key);
                await database.TVShows.InsertOrUpdateAsync(tvshowentry);

                var savedActorMapper = await database.TVShowActorMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);
                var savedGenreMapper = await database.TVShowGenreMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);

                foreach (Actor actor in tvshow.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);

                    var map = new TVShowActorMapper() { ActorId = entry.ActorId, TVShowId = tvshow.TVShowId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await database.TVShowActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in tvshow.Genre) {
                    var entry = new TVShowGenreTableEntry(genre);
                    await database.TVShowGenres.InsertOrUpdateAsync(entry);

                    var map = new TVShowGenreMapper() { TVShowId = tvshow.TVShowId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await database.TVShowGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.TVShowActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await database.TVShowGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await database.TVShows.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            var saved = await database.TVShowSeasons.GetDataAsync();
            foreach (TVShowSeason season in seasons) {
                Debug.WriteLine("Save Season with tvshowid: " + season.TVShowId + " and season: " + season.Season);
                var seasonEntry = new TVShowSeasonTableEntry(season);
                saved.Remove(seasonEntry.Key);
                await database.TVShowSeasons.InsertOrUpdateAsync(seasonEntry);
            }
            await database.TVShowSeasons.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveEpisodes(List<Episode> episodes) {
            var saved = await database.Episodes.GetDataAsync();
            foreach (Episode episode in episodes) {
                Debug.WriteLine("Save Episode with id: " + episode.EpisodeId + " Label: " + episode.Label);
                var episodeEntry = new EpisodeTableEntry(episode);
                saved.Remove(episodeEntry.Key);
                var result = await database.Episodes.InsertOrUpdateAsync(episodeEntry);

                var savedActorMapper = await database.EpisodeActorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedDirectorMapper = await database.EpisodeDirectorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedAudioStreamMapper = await database.EpisodeAudioStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedSubtitleStreamMapper = await database.EpisodeSubtitleStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedVideoStreamMapper = await database.EpisodeVideoStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);

                foreach (Actor actor in episode.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);

                    var map = new EpisodeActorMapper() { ActorId = entry.ActorId, EpisodeId = episode.EpisodeId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await database.EpisodeActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in episode.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    var map = new EpisodeDirectorMapper() { DirectorId = entry.DirectorId, EpisodeId = episode.EpisodeId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await database.EpisodeDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeAudioStreamMapper() { EpisodeId = episode.EpisodeId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await database.EpisodeAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeSubtitleStreamMapper() { EpisodeId = episode.EpisodeId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await database.EpisodeSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeVideoStreamMapper() { EpisodeId = episode.EpisodeId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await database.EpisodeVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.EpisodeActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await database.EpisodeDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await database.EpisodeAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await database.EpisodeSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await database.EpisodeVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await database.Episodes.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveAlbums(List<Album> albums) {
            var saved = await database.Albums.GetDataAsync();
            foreach (Album album in albums) {
                Debug.WriteLine("Save Album with id: " + album.AlbumId);
                var albumEntry = new AlbumTableEntry(album);
                saved.Remove(albumEntry.Key);
                var result = await database.Albums.InsertOrUpdateAsync(albumEntry);

                var savedArtistMapper = await database.AlbumArtistMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);
                var savedGenreMapper = await database.AlbumGenreMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);

                foreach (int artist in album.ArtistId) {
                    var map = new AlbumArtistMapper() { ArtistId = artist, AlbumId = album.AlbumId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await database.AlbumArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in album.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await database.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new AlbumGenreMapper() { AlbumId = album.AlbumId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await database.AlbumGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.AlbumArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await database.AlbumGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await database.Albums.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveArtists(List<Artist> artists) {
            var saved = await database.Artists.GetDataAsync();
            foreach (Artist artist in artists) {
                Debug.WriteLine("Save Artist with id: " + artist.ArtistId);
                var artistEntry = new ArtistTableEntry(artist);
                saved.Remove(artistEntry.Key);
                var result = await database.Artists.InsertOrUpdateAsync(artistEntry);
            }
            await database.Artists.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveSongs(List<Song> songs) {
            var saved = await database.Songs.GetDataAsync();
            foreach (Song song in songs) {
                Debug.WriteLine("Save Song with id: " + song.SongId);
                var songEntry = new SongTableEntry(song);
                saved.Remove(songEntry.Key);
                var result = await database.Songs.InsertOrUpdateAsync(songEntry);

                var savedArtistMapper = await database.SongArtistMapper.GetDataWhereAsync(x => x.SongId == song.SongId);
                var savedGenreMapper = await database.SongGenreMapper.GetDataWhereAsync(x => x.SongId == song.SongId);

                foreach (int artist in song.ArtistId) {
                    var map = new SongArtistMapper() { ArtistId = artist , SongId = song.SongId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await database.SongArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in song.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await database.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new SongGenreMapper() { SongId = song.SongId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await database.SongGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.SongArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await database.SongGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await database.Songs.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveMusicVideos(List<MusicVideo> musicvideos) {
            var saved = await database.MusicVideos.GetDataAsync();
            foreach (MusicVideo musicvideo in musicvideos) {
                Debug.WriteLine("Save MusicVideo with id: " + musicvideo.MusicVideoId);
                var musicVideoEntry = new MusicVideoTableEntry(musicvideo);
                saved.Remove(musicVideoEntry.Key);
                var result = await database.MusicVideos.InsertOrUpdateAsync(musicVideoEntry);

                var savedArtistMapper = await database.MusicVideoArtistMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedAudioStreamMapper = await database.MusicVideoAudioStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedDirectorMapper = await database.MusicVideoDirectorMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedGenreMapper = await database.MusicVideoGenreMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedSubtitleStreamMapper = await database.MusicVideoSubtitleStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedVideoStreamMapper = await database.MusicVideoVideoStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);

                foreach (string artist in musicvideo.Artist) {
                    var entry = new MusicVideoArtistTableEntry(artist);
                    await database.MusicVideoArtists.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoArtistMapper() { MusicVideoArtistId = entry.MusicVideoArtistId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await database.MusicVideoArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in musicvideo.Genre) {
                    var entry = new MusicVideoGenreTableEntry(genre);
                    await database.MusicVideoGenres.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoGenreMapper() { MusicVideoId = musicvideo.MusicVideoId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await database.MusicVideoGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in musicvideo.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoDirectorMapper() { DirectorId = entry.DirectorId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await database.MusicVideoDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoAudioStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await database.MusicVideoAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoSubtitleStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await database.MusicVideoSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoVideoStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await database.MusicVideoVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.MusicVideoArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await database.MusicVideoAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await database.MusicVideoDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await database.MusicVideoGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await database.MusicVideoSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await database.MusicVideoVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await database.MusicVideos.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveMovieSets(List<MovieSet> moviesets) {
            var saved = await database.MovieSets.GetDataAsync();
            foreach (MovieSet movieset in moviesets) {
                Debug.WriteLine("Save MovieSet with id: " + movieset.SetId);
                var entry = new MovieSetTableEntry(movieset);
                saved.Remove(entry.Key);
                var result = await database.MovieSets.InsertOrUpdateAsync(entry);
            }
            await database.MovieSets.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveAddons(List<Addon> addons) {
            var saved = await database.Addons.GetDataAsync();
            foreach (Addon addon in addons) {
                Debug.WriteLine("Save Addon with id: " + addon.AddonId);
                var entry = new AddonTableEntry(addon);
                var result = await database.Addons.InsertOrUpdateAsync(entry);
            }
            await database.Addons.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }

        public async Task SaveMovies(List<Movie> movies) {
            var saved = await database.Movies.GetDataAsync();
            foreach (Movie movie in movies) {
                Debug.WriteLine("Save Movie with id: " + movie.MovieId);
                var movieEntry = new MovieTableEntry(movie);
                saved.Remove(movieEntry.Key);
                var result = await database.Movies.InsertOrUpdateAsync(movieEntry);

                var savedActorMapper = await database.MovieActorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedAudioStreamMapper = await database.MovieAudioStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedDirectorMapper = await database.MovieDirectorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedGenreMapper = await database.MovieGenreMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedSubtitleStreamMapper = await database.MovieSubtitleStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedVideoStreamMapper = await database.MovieVideoStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedMovieSetMapper = await database.MovieMovieSetMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);


                if (movie.SetId != 0) {
                    var map = new MovieMovieSetMapper() { MovieId = movie.MovieId, MovieSetId = movie.SetId };
                    if (!savedMovieSetMapper.Remove(map.Key)) {
                        await database.MovieMovieSetMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in movie.Genre) {
                    var entry = new MovieGenreTableEntry(genre);
                    await database.MovieGenres.InsertOrUpdateAsync(entry);

                    var map = new MovieGenreMapper() { MovieId = movie.MovieId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await database.MovieGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (Actor actor in movie.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);

                    var map = new MovieActorMapper() { ActorId = entry.ActorId, MovieId = movie.MovieId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await database.MovieActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in movie.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    var map = new MovieDirectorMapper() { DirectorId = entry.DirectorId, MovieId = movie.MovieId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await database.MovieDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieAudioStreamMapper() { MovieId = movie.MovieId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await database.MovieAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieSubtitleStreamMapper() { MovieId = movie.MovieId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await database.MovieSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieVideoStreamMapper() { MovieId = movie.MovieId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await database.MovieVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await database.MovieActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await database.MovieAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await database.MovieDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await database.MovieGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await database.MovieMovieSetMapper.RemoveRangeAsync(savedMovieSetMapper.Values);
                await database.MovieSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await database.MovieVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await database.Movies.RemoveRangeAsync(saved.Values);
            await database.SaveChangesAsync();
        }
        #endregion SaveLogic

        private IReadOnlyList<MovieTableEntry> Movies { get; set; }
        private IReadOnlyList<MovieGenreTableEntry> MovieGenres { get; set; } 
        private IReadOnlyList<TVShowTableEntry> TVShows { get; set; }
        private IReadOnlyList<TVShowGenreTableEntry> TVShowGenres { get; set; }

        private IReadOnlyList<MusicVideoTableEntry> MusicVideos { get; set; }
        private IReadOnlyList<MusicVideoGenreTableEntry> MusicVideoGenres { get; set; }
        private IReadOnlyList<SongTableEntry> Songs { get; set; }
        private IReadOnlyList<AlbumTableEntry> Albums { get; set; }
        private IReadOnlyList<ArtistTableEntry> Artists{ get; set; }
        private IReadOnlyList<MusicGenreTableEntry> MusicGenres { get; set; }
        private IReadOnlyList<AddonTableEntry> Addons { get; set; }
        private IReadOnlyList<MovieSetTableEntry> MovieSets { get; set; }


        private IQueryable<TVShowTableEntry> TVShowsWithRelations(DbContext context) {
            return context.Set<TVShowTableEntry>()
                .Include(x => x.Actors).ThenInclude(x => x.Actor)
                .Include(x => x.Genres).ThenInclude(x => x.Genre)
                .Include(x => x.Seasons).ThenInclude(x => x.Episodes);
        }

        private IQueryable<MovieTableEntry> MoviesWithRelations(DbContext context) {
            return context.Set<MovieTableEntry>()
                .Include(x => x.Actors).ThenInclude(x => x.Actor)
                .Include(x => x.AudioStreams).ThenInclude(x => x.AudioStream)
                .Include(x => x.Directors).ThenInclude(x => x.Director)
                .Include(x => x.Genres).ThenInclude(x => x.Genre)
                .Include(x => x.MovieSets).ThenInclude(x => x.MovieSet)
                .Include(x => x.SubtitleStreams).ThenInclude(x => x.SubtitleStream)
                .Include(x => x.VideoStreams).ThenInclude(x => x.VideoStream);
        }

        private IQueryable<MusicVideoTableEntry> MusicVideosWithRelations(DbContext context) {
            return context.Set<MusicVideoTableEntry>()
                .Include(x => x.Artists).ThenInclude(x => x.MusicVideoArtist)
                .Include(x => x.AudioStreams).ThenInclude(x => x.AudioStream)
                .Include(x => x.Directors).ThenInclude(x => x.Director)
                .Include(x => x.Genres).ThenInclude(x => x.Genre)
                .Include(x => x.SubtitleStreams).ThenInclude(x => x.SubtitleStream)
                .Include(x => x.VideoStreams).ThenInclude(x => x.VideoStream);
        }

        private IQueryable<ActorTableEntry> ActorsWithRelations(DbContext context) {
            return context.Set<ActorTableEntry>()
                .Include(x => x.Episodes).ThenInclude(x => x.Episode)
                .Include(x => x.Movies).ThenInclude(x => x.Movie)
                .Include(x => x.TVShows).ThenInclude(x => x.TVShow);
        }   

        private IQueryable<SongTableEntry> SongsWithRelations(DbContext context) {
            return context.Set<SongTableEntry>()
                .Include(x => x.Albums).ThenInclude(x => x.Album)
                .Include(x => x.Artists).ThenInclude(x => x.Artist)
                .Include(x => x.Genres).ThenInclude(x => x.Genre)
                .Include(x => x.Playlists).ThenInclude(x => x.Playlist);
        }

        private IQueryable<AlbumTableEntry> AlbumsWithRelations(DbContext context) {
            return context.Set<AlbumTableEntry>()
                .Include(x => x.Songs).ThenInclude(x => x.Song)
                .Include(x => x.Artists).ThenInclude(x => x.Artist)
                .Include(x => x.Genres).ThenInclude(x => x.Genre);
        }

        private IQueryable<ArtistTableEntry> ArtistsWithRelations(DbContext context) {
            return context.Set<ArtistTableEntry>()
                .Include(x => x.Songs).ThenInclude(x => x.Song)
                .Include(x => x.Albums).ThenInclude(x => x.Album);
        }

        private IQueryable<MovieSetTableEntry> MovieSetsWithRelations(DbContext context) {
            return context.Set<MovieSetTableEntry>()
                .Include(x => x.Movies).ThenInclude(x => x.Movie);
        }

        private async Task LoadMovies() {
            if(Movies == null) {
                using (var context = database.CreateContext()) {
                    Movies = await context.Set<MovieTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadTVShows() {
            if (TVShows == null) {
                using (var context = database.CreateContext()) {
                    TVShows = await context.Set<TVShowTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadTVShowGenres() {
            if (TVShowGenres == null) {
                using (var context = database.CreateContext()) {
                    TVShowGenres = await context.Set<TVShowGenreTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadMovieGenres() {
            if (MovieGenres == null) {
                using (var context = database.CreateContext()) {
                    MovieGenres = await context.Set<MovieGenreTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadMusicVideos() {
            if (MusicVideos == null) {
                using (var context = database.CreateContext()) {
                    MusicVideos = await context.Set<MusicVideoTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadMusicVideoGenres() {
            if (MusicVideoGenres == null) {
                using (var context = database.CreateContext()) {
                    MusicVideoGenres = await context.Set<MusicVideoGenreTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadSongs() {
            if (Songs == null) {
                using (var context = database.CreateContext()) {
                    Songs = await SongsWithRelations(context).ToListAsync();
                }
            }
        }
        private async Task LoadAlbums() {
            if (Albums == null) {
                using (var context = database.CreateContext()) {
                    Albums = await AlbumsWithRelations(context).ToListAsync();
                }
            }
        }

        private async Task LoadArtists() {
            if (Artists == null) {
                using (var context = database.CreateContext()) {
                    Artists = await ArtistsWithRelations(context).ToListAsync();
                }
            }
        }

        private async Task LoadMusicGenres() {
            if (MusicGenres == null) {
                using (var context = database.CreateContext()) {
                    MusicGenres = await context.Set<MusicGenreTableEntry>().ToListAsync();
                }
            }
        }
        private async Task LoadAddons() {
            if (Addons == null) {
                using (var context = database.CreateContext()) {
                    Addons = await context.Set<AddonTableEntry>().ToListAsync();
                }
            }
        }

        private async Task LoadMovieSets() {
            if (MovieSets == null) {
                using (var context = database.CreateContext()) {
                    MovieSets = await context.Set<MovieSetTableEntry>().ToListAsync();
                }
            }
        }

        public async Task<IReadOnlyList<MovieTableEntry>> GetMovies() {
            await LoadMovies();
            return Movies;
        }

        public async Task<MovieTableEntry> GetMovie(MovieTableEntry movie) {
            using (var context = database.CreateContext()) {
                return await MoviesWithRelations(context).FirstOrDefaultAsync(x => x.MovieId == movie.MovieId);
            }
        }

        public async Task<IReadOnlyList<MovieGenreTableEntry>> GetMovieGenres() {
            await LoadMovieGenres();
            return MovieGenres;
        }

        public async Task<IEnumerable<TVShowTableEntry>> GetTVShows() {
            await LoadTVShows();
            return TVShows;
        }

        public async Task<TVShowTableEntry> GetTVShow(TVShowTableEntry tvshow) {
            using (var context = database.CreateContext()) {
                return await TVShowsWithRelations(context).FirstOrDefaultAsync(x => x.TVShowId == tvshow.TVShowId);
            }
        }

        public async Task<IReadOnlyList<TVShowGenreTableEntry>> GetTVShowGenres() {
            await LoadTVShowGenres();
            return TVShowGenres;
        }

        public async Task<ActorTableEntry> GetActor(ActorTableEntry actor) {
            using (var context = database.CreateContext()) {
                return await ActorsWithRelations(context).FirstOrDefaultAsync(x => x.ActorId == actor.ActorId);
            }
        }

        public async Task<IEnumerable<MusicVideoTableEntry>> GetMusicVideo() {
            await LoadMusicVideos();
            return MusicVideos;
        }

        public async Task<MusicVideoTableEntry> GetMusicVideo(MusicVideoTableEntry musicVideo) {
            using (var context = database.CreateContext()) {
                return await MusicVideosWithRelations(context).FirstOrDefaultAsync(x => x.MusicVideoId == musicVideo.MusicVideoId);
            }
        }


        public async Task<IEnumerable<SongTableEntry>> GetSongs() {
            await LoadSongs();
            return Songs;
        }

        public async Task<SongTableEntry> GetSong(SongTableEntry song) {
            using (var context = database.CreateContext()) {
                return await SongsWithRelations(context).FirstOrDefaultAsync(x => x.SongId == song.SongId);
            }
        }

        public async Task<IEnumerable<AlbumTableEntry>> GetAlbums() {
            await LoadAlbums();
            return Albums;
        }

        public async Task<AlbumTableEntry> GetAlbum(AlbumTableEntry album) {
            using (var context = database.CreateContext()) {
                return await AlbumsWithRelations(context).FirstOrDefaultAsync(x => x.AlbumId == album.AlbumId);
            }
        }

        public async Task<IEnumerable<ArtistTableEntry>> GetArtists() {
            await LoadArtists();
            return Artists;
        }

        public async Task<ArtistTableEntry> GetArtist(ArtistTableEntry artist) {
            using (var context = database.CreateContext()) {
                return await ArtistsWithRelations(context).FirstOrDefaultAsync(x => x.ArtistId == artist.ArtistId);
            }
        }

        public async Task<IEnumerable<AddonTableEntry>> GetAddons() {
            await LoadAddons();
            return Addons;
        }

        public async Task<AddonTableEntry> GetAddon(AddonTableEntry addon) {
            await LoadAddons();
            return Addons.FirstOrDefault(x => x.AddonId == addon.AddonId);
        }

        public async Task<IEnumerable<MovieSetTableEntry>> GetMovieSets() {
            await LoadMovieSets();
            return MovieSets;
        }

        public async Task<MovieSetTableEntry> GetMovieSet(MovieSetTableEntry movieSet) {
            using (var context = database.CreateContext()) {
                return await MovieSetsWithRelations(context).FirstOrDefaultAsync(x => x.SetId == movieSet.SetId);
            }
        }
    }
}
