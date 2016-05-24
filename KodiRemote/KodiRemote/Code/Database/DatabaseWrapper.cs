using KodiRemote.Code.Common;
using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KAddons.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseWrapper :PropertyChangedBase {
        public DatabaseOperations Operations { get; set; }
        public DatabaseContextWrapper databaseWrapper { get; set; }

        public DatabaseWrapper(string name) {
            this.databaseWrapper = new DatabaseContextWrapper(name);
        }

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
            var saved = await databaseWrapper.TVShows.GetDataAsync();
            foreach (TVShow tvshow in tvshows) {
                Debug.WriteLine("Save TVShow with id: " + tvshow.TVShowId);
                var tvshowentry = new TVShowTableEntry(tvshow);
                saved.Remove(tvshowentry.Key);
                await databaseWrapper.TVShows.InsertOrUpdateAsync(tvshowentry);

                var savedActorMapper = await databaseWrapper.TVShowActorMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);
                var savedGenreMapper = await databaseWrapper.TVShowGenreMapper.GetDataWhereAsync(x => x.TVShowId == tvshow.TVShowId);

                foreach (Actor actor in tvshow.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await databaseWrapper.Actors.InsertOrUpdateAsync(entry);

                    var map = new TVShowActorMapper() { ActorId = entry.ActorId, TVShowId = tvshow.TVShowId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await databaseWrapper.TVShowActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in tvshow.Genre) {
                    var entry = new TVShowGenreTableEntry(genre);
                    await databaseWrapper.TVShowGenres.InsertOrUpdateAsync(entry);

                    var map = new TVShowGenreMapper() { TVShowId = tvshow.TVShowId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await databaseWrapper.TVShowGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.TVShowActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await databaseWrapper.TVShowGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await databaseWrapper.TVShows.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            var saved = await databaseWrapper.TVShowSeasons.GetDataAsync();
            foreach (TVShowSeason season in seasons) {
                Debug.WriteLine("Save Season with tvshowid: " + season.TVShowId + " and season: " + season.Season);
                var seasonEntry = new TVShowSeasonTableEntry(season);
                saved.Remove(seasonEntry.Key);
                await databaseWrapper.TVShowSeasons.InsertOrUpdateAsync(seasonEntry);
            }
            await databaseWrapper.TVShowSeasons.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveEpisodes(List<Episode> episodes) {
            var saved = await databaseWrapper.Episodes.GetDataAsync();
            foreach (Episode episode in episodes) {
                Debug.WriteLine("Save Episode with id: " + episode.EpisodeId + " Label: " + episode.Label);
                var episodeEntry = new EpisodeTableEntry(episode);
                saved.Remove(episodeEntry.Key);
                var result = await databaseWrapper.Episodes.InsertOrUpdateAsync(episodeEntry);

                var savedActorMapper = await databaseWrapper.EpisodeActorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedDirectorMapper = await databaseWrapper.EpisodeDirectorMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedAudioStreamMapper = await databaseWrapper.EpisodeAudioStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedSubtitleStreamMapper = await databaseWrapper.EpisodeSubtitleStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);
                var savedVideoStreamMapper = await databaseWrapper.EpisodeVideoStreamMapper.GetDataWhereAsync(x => x.EpisodeId == episode.EpisodeId);

                foreach (Actor actor in episode.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await databaseWrapper.Actors.InsertOrUpdateAsync(entry);

                    var map = new EpisodeActorMapper() { ActorId = entry.ActorId, EpisodeId = episode.EpisodeId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await databaseWrapper.EpisodeActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in episode.Director) {
                    var entry = new DirectorTableEntry(director);
                    await databaseWrapper.Directors.InsertOrUpdateAsync(entry);

                    var map = new EpisodeDirectorMapper() { DirectorId = entry.DirectorId, EpisodeId = episode.EpisodeId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await databaseWrapper.EpisodeDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await databaseWrapper.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeAudioStreamMapper() { EpisodeId = episode.EpisodeId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.EpisodeAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await databaseWrapper.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeSubtitleStreamMapper() { EpisodeId = episode.EpisodeId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.EpisodeSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in episode.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await databaseWrapper.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new EpisodeVideoStreamMapper() { EpisodeId = episode.EpisodeId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.EpisodeVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.EpisodeActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await databaseWrapper.EpisodeDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await databaseWrapper.EpisodeAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await databaseWrapper.EpisodeSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await databaseWrapper.EpisodeVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await databaseWrapper.Episodes.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveAlbums(List<Album> albums) {
            var saved = await databaseWrapper.Albums.GetDataAsync();
            foreach (Album album in albums) {
                Debug.WriteLine("Save Album with id: " + album.AlbumId);
                var albumEntry = new AlbumTableEntry(album);
                saved.Remove(albumEntry.Key);
                var result = await databaseWrapper.Albums.InsertOrUpdateAsync(albumEntry);

                var savedArtistMapper = await databaseWrapper.AlbumArtistMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);
                var savedGenreMapper = await databaseWrapper.AlbumGenreMapper.GetDataWhereAsync(x => x.AlbumId == album.AlbumId);

                foreach (int artist in album.ArtistId) {
                    var map = new AlbumArtistMapper() { ArtistId = artist, AlbumId = album.AlbumId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await databaseWrapper.AlbumArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in album.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await databaseWrapper.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new AlbumGenreMapper() { AlbumId = album.AlbumId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await databaseWrapper.AlbumGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.AlbumArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await databaseWrapper.AlbumGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await databaseWrapper.Albums.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveArtists(List<Artist> artists) {
            var saved = await databaseWrapper.Artists.GetDataAsync();
            foreach (Artist artist in artists) {
                Debug.WriteLine("Save Artist with id: " + artist.ArtistId);
                var artistEntry = new ArtistTableEntry(artist);
                saved.Remove(artistEntry.Key);
                var result = await databaseWrapper.Artists.InsertOrUpdateAsync(artistEntry);
            }
            await databaseWrapper.Artists.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveSongs(List<Song> songs) {
            var saved = await databaseWrapper.Songs.GetDataAsync();
            foreach (Song song in songs) {
                Debug.WriteLine("Save Song with id: " + song.SongId);
                var songEntry = new SongTableEntry(song);
                saved.Remove(songEntry.Key);
                var result = await databaseWrapper.Songs.InsertOrUpdateAsync(songEntry);

                var savedArtistMapper = await databaseWrapper.SongArtistMapper.GetDataWhereAsync(x => x.SongId == song.SongId);
                var savedGenreMapper = await databaseWrapper.SongGenreMapper.GetDataWhereAsync(x => x.SongId == song.SongId);

                foreach (int artist in song.ArtistId) {
                    var map = new SongArtistMapper() { ArtistId = artist , SongId = song.SongId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await databaseWrapper.SongArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in song.Genre) {
                    var entry = new MusicGenreTableEntry(genre);
                    await databaseWrapper.MusicGenres.InsertOrUpdateAsync(entry);

                    var map = new SongGenreMapper() { SongId = song.SongId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await databaseWrapper.SongGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.SongArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await databaseWrapper.SongGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
            }
            await databaseWrapper.Songs.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveMusicVideos(List<MusicVideo> musicvideos) {
            var saved = await databaseWrapper.MusicVideos.GetDataAsync();
            foreach (MusicVideo musicvideo in musicvideos) {
                Debug.WriteLine("Save MusicVideo with id: " + musicvideo.MusicVideoId);
                var musicVideoEntry = new MusicVideoTableEntry(musicvideo);
                saved.Remove(musicVideoEntry.Key);
                var result = await databaseWrapper.MusicVideos.InsertOrUpdateAsync(musicVideoEntry);

                var savedArtistMapper = await databaseWrapper.MusicVideoArtistMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedAudioStreamMapper = await databaseWrapper.MusicVideoAudioStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedDirectorMapper = await databaseWrapper.MusicVideoDirectorMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedGenreMapper = await databaseWrapper.MusicVideoGenreMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedSubtitleStreamMapper = await databaseWrapper.MusicVideoSubtitleStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                var savedVideoStreamMapper = await databaseWrapper.MusicVideoVideoStreamMapper.GetDataWhereAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);

                foreach (string artist in musicvideo.Artist) {
                    var entry = new MusicVideoArtistTableEntry(artist);
                    await databaseWrapper.MusicVideoArtists.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoArtistMapper() { MusicVideoArtistId = entry.MusicVideoArtistId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedArtistMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoArtistMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in musicvideo.Genre) {
                    var entry = new MusicVideoGenreTableEntry(genre);
                    await databaseWrapper.MusicVideoGenres.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoGenreMapper() { MusicVideoId = musicvideo.MusicVideoId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in musicvideo.Director) {
                    var entry = new DirectorTableEntry(director);
                    await databaseWrapper.Directors.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoDirectorMapper() { DirectorId = entry.DirectorId, MusicVideoId = musicvideo.MusicVideoId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await databaseWrapper.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoAudioStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await databaseWrapper.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoSubtitleStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in musicvideo.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await databaseWrapper.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MusicVideoVideoStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MusicVideoVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.MusicVideoArtistMapper.RemoveRangeAsync(savedArtistMapper.Values);
                await databaseWrapper.MusicVideoAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await databaseWrapper.MusicVideoDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await databaseWrapper.MusicVideoGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await databaseWrapper.MusicVideoSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await databaseWrapper.MusicVideoVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await databaseWrapper.MusicVideos.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveMovieSets(List<MovieSet> moviesets) {
            var saved = await databaseWrapper.MovieSets.GetDataAsync();
            foreach (MovieSet movieset in moviesets) {
                Debug.WriteLine("Save MovieSet with id: " + movieset.SetId);
                var entry = new MovieSetTableEntry(movieset);
                saved.Remove(entry.Key);
                var result = await databaseWrapper.MovieSets.InsertOrUpdateAsync(entry);
            }
            await databaseWrapper.MovieSets.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveAddons(List<Addon> addons) {
            var saved = await databaseWrapper.Addons.GetDataAsync();
            foreach (Addon addon in addons) {
                Debug.WriteLine("Save Addon with id: " + addon.AddonId);
                var entry = new AddonTableEntry(addon);
                var result = await databaseWrapper.Addons.InsertOrUpdateAsync(entry);
            }
            await databaseWrapper.Addons.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }

        private async Task SaveMovies(List<Movie> movies) {
            var saved = await databaseWrapper.Movies.GetDataAsync();
            foreach (Movie movie in movies) {
                Debug.WriteLine("Save Movie with id: " + movie.MovieId);
                var movieEntry = new MovieTableEntry(movie);
                saved.Remove(movieEntry.Key);
                var result = await databaseWrapper.Movies.InsertOrUpdateAsync(movieEntry);

                var savedActorMapper = await databaseWrapper.MovieActorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedAudioStreamMapper = await databaseWrapper.MovieAudioStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedDirectorMapper = await databaseWrapper.MovieDirectorMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedGenreMapper = await databaseWrapper.MovieGenreMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedSubtitleStreamMapper = await databaseWrapper.MovieSubtitleStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedVideoStreamMapper = await databaseWrapper.MovieVideoStreamMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);
                var savedMovieSetMapper = await databaseWrapper.MovieMovieSetMapper.GetDataWhereAsync(x => x.MovieId == movie.MovieId);


                if (movie.SetId != 0) {
                    var map = new MovieMovieSetMapper() { MovieId = movie.MovieId, MovieSetId = movie.SetId };
                    if (!savedMovieSetMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieMovieSetMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string genre in movie.Genre) {
                    var entry = new MovieGenreTableEntry(genre);
                    await databaseWrapper.MovieGenres.InsertOrUpdateAsync(entry);

                    var map = new MovieGenreMapper() { MovieId = movie.MovieId, GenreId = entry.GenreId };
                    if (!savedGenreMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieGenreMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (Actor actor in movie.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await databaseWrapper.Actors.InsertOrUpdateAsync(entry);

                    var map = new MovieActorMapper() { ActorId = entry.ActorId, MovieId = movie.MovieId, Role = actor.Role };
                    if (!savedActorMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieActorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (string director in movie.Director) {
                    var entry = new DirectorTableEntry(director);
                    await databaseWrapper.Directors.InsertOrUpdateAsync(entry);

                    var map = new MovieDirectorMapper() { DirectorId = entry.DirectorId, MovieId = movie.MovieId };
                    if (!savedDirectorMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieDirectorMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await databaseWrapper.AudioStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieAudioStreamMapper() { MovieId = movie.MovieId, AudioStreamId = entry.AudioStreamId };
                    if (!savedAudioStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieAudioStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await databaseWrapper.SubtitleStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieSubtitleStreamMapper() { MovieId = movie.MovieId, SubtitleStreamId = entry.SubtitleStreamId };
                    if (!savedSubtitleStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieSubtitleStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                foreach (var stream in movie.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await databaseWrapper.VideoStreams.InsertOrUpdateAsync(entry);

                    var map = new MovieVideoStreamMapper() { MovieId = movie.MovieId, VideoStreamId = entry.VideoStreamId };
                    if (!savedVideoStreamMapper.Remove(map.Key)) {
                        await databaseWrapper.MovieVideoStreamMapper.InsertOrUpdateAsync(map);
                    }
                }

                await databaseWrapper.MovieActorMapper.RemoveRangeAsync(savedActorMapper.Values);
                await databaseWrapper.MovieAudioStreamMapper.RemoveRangeAsync(savedAudioStreamMapper.Values);
                await databaseWrapper.MovieDirectorMapper.RemoveRangeAsync(savedDirectorMapper.Values);
                await databaseWrapper.MovieGenreMapper.RemoveRangeAsync(savedGenreMapper.Values);
                await databaseWrapper.MovieMovieSetMapper.RemoveRangeAsync(savedMovieSetMapper.Values);
                await databaseWrapper.MovieSubtitleStreamMapper.RemoveRangeAsync(savedSubtitleStreamMapper.Values);
                await databaseWrapper.MovieVideoStreamMapper.RemoveRangeAsync(savedVideoStreamMapper.Values);
            }
            await databaseWrapper.Movies.RemoveRangeAsync(saved.Values);
            await databaseWrapper.SaveChangesAsync();
        }
        #endregion SaveLogic
    }
}
