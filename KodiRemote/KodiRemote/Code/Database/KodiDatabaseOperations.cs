using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.Utils;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
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

namespace KodiRemote.Code.Essentials {
    public abstract partial class Kodi : PropertyChangedBase, IDisposable {
        private bool databaseWorking;
        public bool DatabaseWorking {
            get {
                return databaseWorking;
            }
            private set {
                databaseWorking = value;
                RaisePropertyChanged();
            }
        }
        
        #region SaveLogic
        private async Task SaveTVShows(List<TVShow> tvshows) {
            var saved = await Database.TVShows.GetDataAsync();
            foreach (TVShow tvshow in tvshows) {
                Debug.WriteLine("Save TVShow with id: " + tvshow.TVShowId);
                var tvshowentry = new TVShowTableEntry(tvshow);
                saved.Remove(tvshowentry.Key);
                await Database.TVShows.InsertOrUpdateAsync(tvshowentry);

                var savedActorMapper = await Database.TVShowActorMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);
                var savedGenreMapper = await Database.TVShowGenreMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);

                foreach (Actor actor in tvshow.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await Database.Actors.InsertOrUpdateAsync(entry);

                    var map = new TVShowActorMapper() { ActorId = entry.ActorId, TVShowId = tvshow.TVShowId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await Database.TVShowActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in tvshow.Genre) {
                    var entry = new TVShowGenreTableEntry(genre);
                    await Database.TVShowGenres.InsertOrUpdateAsync(entry);

                    var map = new TVShowGenreMapper() { TVShowId = tvshow.TVShowId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await Database.TVShowGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.TVShowActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await Database.TVShowGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await Database.TVShows.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            var saved = await Database.TVShowSeasons.GetDataAsync();
            foreach (TVShowSeason season in seasons) {
                Debug.WriteLine("Save Season with tvshowid: " + season.TVShowId + " and season: " + season.Season);
                var seasonEntry = new TVShowSeasonTableEntry(season);
                saved.Remove(seasonEntry.Key);
                await Database.TVShowSeasons.InsertOrUpdateAsync(seasonEntry);
            }
            await Database.TVShowSeasons.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveEpisodes(List<Episode> episodes) {
            var saved = await Database.Episodes.GetDataAsync();
            foreach (Episode episode in episodes) {
                Debug.WriteLine("Save Episode with id: " + episode.EpisodeId + " Label: " + episode.Label);
                var episodeEntry = new EpisodeTableEntry(episode);
                saved.Remove(episodeEntry.Key);
                var result = await Database.Episodes.InsertOrUpdateAsync(episodeEntry);

                var savedActorMapper = await Database.EpisodeActorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedDirectorMapper = await Database.EpisodeDirectorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedAudioStreamMapper = await Database.EpisodeAudioStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedSubtitleStreamMapper = await Database.EpisodeSubtitleStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedVideoStreamMapper = await Database.EpisodeVideoStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);

                foreach (Actor actor in episode.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await Database.Actors.InsertOrUpdateAsync(entry);
                    
                    var map = new EpisodeActorMapper() { ActorId = entry.ActorId, EpisodeId = episode.EpisodeId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await Database.EpisodeActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in episode.Director) {
                    var entry = new DirectorTableEntry(director);
                    await Database.Directors.InsertOrUpdateAsync(entry);

                    var map = new EpisodeDirectorMapper() { DirectorId = entry.DirectorId, EpisodeId = episode.EpisodeId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await Database.EpisodeDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await Database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeAudioStreamMapper() { EpisodeId = episode.EpisodeId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await Database.EpisodeAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await Database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeSubtitleStreamMapper() { EpisodeId = episode.EpisodeId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await Database.EpisodeSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await Database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeVideoStreamMapper() { EpisodeId = episode.EpisodeId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await Database.EpisodeVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.EpisodeActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await Database.EpisodeDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await Database.EpisodeAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await Database.EpisodeSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await Database.EpisodeVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await Database.Episodes.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveAlbums(List<Album> albums) {
            var saved = await Database.Albums.GetDataAsync();
            foreach (Album album in albums) {
                Debug.WriteLine("Save Album with id: " + album.AlbumId);
                var albumEntry = new AlbumTableEntry(album);
                saved.Remove(albumEntry.Key);
                var result = await Database.Albums.InsertOrUpdateAsync(albumEntry);

                var savedArtistMapper = await Database.AlbumArtistMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);
                var savedGenreMapper = await Database.AlbumGenreMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);

                foreach (int artist in album.ArtistId) {
                    var map = new AlbumArtistMapper() { ArtistId = artist, AlbumId = album.AlbumId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await Database.AlbumArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in album.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await Database.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new AlbumGenreMapper() { AlbumId = album.AlbumId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await Database.AlbumGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.AlbumArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await Database.AlbumGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await Database.Albums.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveArtists(List<Artist> artists) {
            var saved = await Database.Artists.GetDataAsync();
            foreach (Artist artist in artists) {
                Debug.WriteLine("Save Artist with id: " + artist.ArtistId);
                var artistEntry = new ArtistTableEntry(artist);
                saved.Remove(artistEntry.Key);
                var result = await Database.Artists.InsertOrUpdateAsync(artistEntry);
            }
            await Database.Artists.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveSongs(List<Song> songs) {
            var saved = await Database.Songs.GetDataAsync();
            foreach (Song song in songs) {
                Debug.WriteLine("Save Song with id: " + song.SongId);
                var songEntry = new SongTableEntry(song);
                saved.Remove(songEntry.Key);
                var result = await Database.Songs.InsertOrUpdateAsync(songEntry);

                var savedArtistMapper = await Database.SongArtistMapper.GetDataWhereAsync(x => x.SongId == song.SongId);
                var savedGenreMapper = await Database.SongGenreMapper.GetDataWhereAsync(x => x.SongId == song.SongId);
                
                foreach (int artist in song.ArtistId) {
                    var map = new SongArtistMapper() { ArtistId = artist , SongId = song.SongId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await Database.SongArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in song.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await Database.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new SongGenreMapper() { SongId = song.SongId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await Database.SongGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.SongArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await Database.SongGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await Database.Songs.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveMusicVideos(List<MusicVideo> musicvideos) {
            var saved = await Database.MusicVideos.GetDataAsync();
            foreach (MusicVideo musicvideo in musicvideos) {
                Debug.WriteLine("Save MusicVideo with id: " + musicvideo.MusicVideoId);
                var musicVideoEntry = new MusicVideoTableEntry(musicvideo);
                saved.Remove(musicVideoEntry.Key);
                var result = await Database.MusicVideos.InsertOrUpdateAsync(musicVideoEntry);

                var savedArtistMapper = await Database.MusicVideoArtistMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedAudioStreamMapper = await Database.MusicVideoAudioStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedDirectorMapper = await Database.MusicVideoDirectorMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedGenreMapper = await Database.MusicVideoGenreMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedSubtitleStreamMapper = await Database.MusicVideoSubtitleStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedVideoStreamMapper = await Database.MusicVideoVideoStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);

                foreach (string artist in musicvideo.Artist) {
                    var entry = new MusicVideoArtistTableEntry(artist);
                    await Database.MusicVideoArtists.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoArtistMapper() { MusicVideoArtistId = entry.MusicVideoArtistId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await Database.MusicVideoArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in musicvideo.Genre) {
                    var entry = new MusicVideoGenreTableEntry(genre);
                    await Database.MusicVideoGenres.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoGenreMapper() { MusicVideoId = musicvideo.MusicVideoId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await Database.MusicVideoGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in musicvideo.Director) {
                    var entry = new DirectorTableEntry(director);
                    await Database.Directors.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoDirectorMapper() { DirectorId = entry.DirectorId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await Database.MusicVideoDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await Database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoAudioStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await Database.MusicVideoAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await Database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoSubtitleStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await Database.MusicVideoSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await Database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoVideoStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await Database.MusicVideoVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.MusicVideoArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await Database.MusicVideoAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await Database.MusicVideoDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await Database.MusicVideoGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await Database.MusicVideoSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await Database.MusicVideoVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await Database.MusicVideos.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveMovieSets(List<MovieSet> moviesets) {
            var saved = await Database.MovieSets.GetDataAsync();
            foreach (MovieSet movieset in moviesets) {
                Debug.WriteLine("Save MovieSet with id: " + movieset.SetId);
                var entry = new MovieSetTableEntry(movieset);
                saved.Remove(entry.Key);
                var result = await Database.MovieSets.InsertOrUpdateAsync(entry);
            }
            await Database.MovieSets.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }
        
        private async Task SaveAddons(List<Addon> addons) {
            var saved = await Database.Addons.GetDataAsync();
            foreach (Addon addon in addons) {
                Debug.WriteLine("Save Addon with id: " + addon.AddonId);
                var entry = new AddonTableEntry(addon);
                var result = await Database.Addons.InsertOrUpdateAsync(entry);
            }
            await Database.Addons.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }

        private async Task SaveMovies(List<Movie> movies) {
            var saved = await Database.Movies.GetDataAsync();
            foreach (Movie movie in movies) {
                Debug.WriteLine("Save Movie with id: " + movie.MovieId);
                var movieEntry = new MovieTableEntry(movie);
                saved.Remove(movieEntry.Key);
                var result = await Database.Movies.InsertOrUpdateAsync(movieEntry);

                var savedActorMapper = await Database.MovieActorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedAudioStreamMapper = await Database.MovieAudioStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedDirectorMapper = await Database.MovieDirectorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedGenreMapper = await Database.MovieGenreMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedSubtitleStreamMapper = await Database.MovieSubtitleStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedVideoStreamMapper = await Database.MovieVideoStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedMovieSetMapper = await Database.MovieMovieSetMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);


                if (movie.SetId != 0) {
                    var map = new MovieMovieSetMapper() { MovieId = movie.MovieId, MovieSetId = movie.SetId };
                    if (!savedMovieSetMapper.Remove(map.Key)) {
                        await Database.MovieMovieSetMapper.InsertOrUpdateAsync(map);
                    }
                }
                
                foreach (string genre in movie.Genre) {
                    var entry = new MovieGenreTableEntry(genre);
                    await Database.MovieGenres.InsertOrUpdateAsync(entry);

                    var map = new MovieGenreMapper() { MovieId = movie.MovieId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await Database.MovieGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (Actor actor in movie.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await Database.Actors.InsertOrUpdateAsync(entry);
                    
                    var map = new MovieActorMapper() { ActorId = entry.ActorId, MovieId = movie.MovieId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await Database.MovieActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in movie.Director) {
                    var entry = new DirectorTableEntry(director);
                    await Database.Directors.InsertOrUpdateAsync(entry);

                    var map = new MovieDirectorMapper() { DirectorId = entry.DirectorId, MovieId = movie.MovieId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await Database.MovieDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await Database.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieAudioStreamMapper() { MovieId = movie.MovieId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await Database.MovieAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await Database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieSubtitleStreamMapper() { MovieId = movie.MovieId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await Database.MovieSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await Database.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieVideoStreamMapper() { MovieId = movie.MovieId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await Database.MovieVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await Database.MovieActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await Database.MovieAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await Database.MovieDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await Database.MovieGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await Database.MovieMovieSetMapper.RemoveRangeAsync(savedMovieSetMapper.Values);
                await Database.MovieSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await Database.MovieVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await Database.Movies.RemoveRangeAsync(saved.Values);
            await Database.SaveChangesAsync();
        }
        #endregion SaveLogic

        #region GatherUpdateData
        const int LIMIT = 20;
        private async Task UpdateDatabase() {
            DatabaseWorking = true;
            var first = DateTime.Now;
            var tvShowIds = await UpdateTVShows();
            var tvShowAndSeasonIds = await UpdateTVShowSeasons(tvShowIds);
            await UpdateEpisodes( tvShowAndSeasonIds);
            List<MovieSet> moviesets = await Update<MovieSet>(UpdateMovieSets);
            await SaveMovieSets(moviesets);
            List<Movie> movies = await Update<Movie>(UpdateMovies);
            await SaveMovies(movies);
            List<MusicVideo> musicvideos = await Update<MusicVideo>(UpdateMusicVideos);
            await SaveMusicVideos(musicvideos);
            List<Artist> artists = await Update<Artist>(UpdateArtists);
            artists.AddRange(await Update<Artist>(UpdateArtists2));
            await SaveArtists(artists);
            List<Song> songs = await Update<Song>(UpdateSongs);
            await SaveSongs(songs);
            List<Album> albums = await Update<Album>(UpdateAlbums);
            await SaveAlbums(albums);
            List<Addon> addons = await Update<Addon>(UpdateAddons);
            await SaveAddons(addons);
            Debug.WriteLine("time taken: " + DateTime.Now.Subtract(first).TotalSeconds);
            DatabaseWorking = false;
        }

        private async Task<List<T>> Update<T>(Func<List<T>, Limits, Task<CollectionResultBase>> function) {
            CollectionResultBase result;
            List<T> list = new List<T>();
            int i = 0;
            do {
                result = await function.Invoke(list, new Limits(i, i + LIMIT));
                i += LIMIT;
            } while (result != null && result.Limits.End != result.Limits.Total);
            return list;
        }

        private async Task<CollectionResultBase> UpdateAddons(List<Addon> list, Limits limits) {
            AddonsResult result = await Addons.GetAddons(ContentEnum.Null, EnabledEnum.All , AddonField.WithAll(), limits: limits);
            if (result != null) {
                list.AddRange(result.Addons);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateSongs(List<Song> list, Limits limits) {
            SongsResult result = await AudioLibrary.GetSongs(SongField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Songs);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateArtists(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateArtists2(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), albumartistsonly: true, limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateAlbums(List<Album> list, Limits limits) {
            AlbumsResult result = await AudioLibrary.GetAlbums(AlbumField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Albums);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateMusicVideos(List<MusicVideo> list, Limits limits) {
            MusicVideosResult result = await VideoLibrary.GetMusicVideos(MusicVideoField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MusicVideos);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateMovieSets(List<MovieSet> list, Limits limits) {
            MovieSetsResult result = await VideoLibrary.GetMovieSets(MovieSetField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MovieSets);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateMovies(List<Movie> list, Limits limits) {
            MoviesResult result = await VideoLibrary.GetMovies(MovieField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Movies);
            }
            return result;
        }

        private async Task UpdateEpisodes(Dictionary<int, List<int>> ids) {
            EpisodesResult result;
            List<Episode> episodes = new List<Episode>();
            foreach (int tvshowId in ids.Keys) {
                List<int> seasonIds;
                ids.TryGetValue(tvshowId, out seasonIds);
                int i = 0;
                do {
                    result = await VideoLibrary.GetEpisodes(EpisodeField.WithMine(), tvshowId, limits: new Limits(i, i + LIMIT));
                    i += LIMIT;
                    if (result != null) {
                        episodes.AddRange(result.Episodes);
                    }
                } while (result != null && result.Limits.End != result.Limits.Total);
            }
            await SaveEpisodes(episodes);
        }

        private async Task<Dictionary<int, List<int>>> UpdateTVShowSeasons(List<int> tvShowIds) {
            TVShowSeasonsResult result;
            List<TVShowSeason> seasons = new List<TVShowSeason>();
            var ids = new Dictionary<int, List<int>>();
            foreach (int i in tvShowIds) {
                result = await VideoLibrary.GetSeasons(i, SeasonField.WithMine());
                if (result != null) {
                    ids.Add(i, new List<int>(result.TVShowSeasons.Select(x => x.Season)));
                    seasons.AddRange(result.TVShowSeasons);
                }
            }
            await SaveTVShowSeasons(seasons);
            return ids;
        }

        private async Task<List<int>> UpdateTVShows() {
            TVShowsResult result;
            List<int> tvShowIds = new List<int>();
            List<TVShow> tvShow = new List<TVShow>();
            int i = 0;
            do {
                result = await VideoLibrary.GetTVShows(TVShowField.WithMine(), limits: new Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    tvShowIds.AddRange(result.TVShows.Select(x => x.TVShowId));
                    tvShow.AddRange(result.TVShows);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await SaveTVShows(tvShow);
            return tvShowIds;
        }
        #endregion GatherUpdateData
    }
}
