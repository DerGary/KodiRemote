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

namespace KodiRemote.Code.Database {
    public class DatabaseConnection {
        private DatabaseContextWrapper database;
        private KodiSettings settings;

        public async Task Init(KodiSettings settings) {
            database = new DatabaseContextWrapper();
            await database.Init(settings.Name);
            this.settings = settings;
        }

        public async Task SaveTVShows(List<TVShow> tvshows) {
            foreach (TVShow tvshow in tvshows) {
                Debug.WriteLine("Save TVShow with id: " + tvshow.TVShowId);
                var tvshowentry = new TVShowTableEntry(tvshow);
                var result = await database.TVShows.InsertOrUpdateAsync(tvshowentry);
                if(result == InsertOrUpdate.Update) {
                    await database.TVShowActorMapper.RemoveAllAsync(x => x.TVShowId == tvshow.TVShowId);
                    await database.TVShowGenreMapper.RemoveAllAsync(x => x.TVShowId == tvshow.TVShowId);
                }
                foreach (Actor actor in tvshow.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);
                    await database.TVShowActorMapper.InsertOrUpdateAsync(new TVShowActorMapper() { ActorId = entry.ActorId, TVShowId = tvshow.TVShowId, Role = actor.Role });
                }
                foreach (string genre in tvshow.Genre) {
                    var entry = new TVShowGenreTableEntry(genre);
                    await database.TVShowGenres.InsertOrUpdateAsync(entry);
                    await database.TVShowGenreMapper.InsertOrUpdateAsync(new TVShowGenreMapper() { TVShowId = tvshow.TVShowId, GenreId = entry.GenreId });
                }
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            foreach (TVShowSeason season in seasons) {
                Debug.WriteLine("Save Season with tvshowid: " + season.TVShowId + " and season: " + season.Season);
                var seasonEntry = new TVShowSeasonTableEntry(season);
                await database.TVShowSeasons.InsertOrUpdateAsync(seasonEntry);
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveEpisodes(List<Episode> episodes) {
            foreach (Episode episode in episodes) {
                Debug.WriteLine("Save Episode with id: " + episode.EpisodeId + " Label: " + episode.Label);
                var episodeEntry = new EpisodeTableEntry(episode);
                var result = await database.Episodes.InsertOrUpdateAsync(episodeEntry);
                if (result == InsertOrUpdate.Update) {
                    await database.EpisodeActorMapper.RemoveAllAsync(x => x.EpisodeId == episode.EpisodeId);
                    await database.EpisodeDirectorMapper.RemoveAllAsync(x => x.EpisodeId == episode.EpisodeId);
                    await database.EpisodeAudioStreamMapper.RemoveAllAsync(x => x.EpisodeId == episode.EpisodeId);
                    await database.EpisodeSubtitleStreamMapper.RemoveAllAsync(x => x.EpisodeId == episode.EpisodeId);
                    await database.EpisodeVideoStreamMapper.RemoveAllAsync(x => x.EpisodeId == episode.EpisodeId);
                }
                
                foreach (Actor actor in episode.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);

                    await database.EpisodeActorMapper.InsertOrUpdateAsync(new EpisodeActorMapper() { ActorId = entry.ActorId, EpisodeId = episode.EpisodeId, Role = actor.Role });
                }

                foreach (string director in episode.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    await database.EpisodeDirectorMapper.InsertOrUpdateAsync(new EpisodeDirectorMapper() { DirectorId = entry.DirectorId, EpisodeId = episode.EpisodeId });
                }

                foreach (var stream in episode.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    await database.EpisodeAudioStreamMapper.InsertOrUpdateAsync(new EpisodeAudioStreamMapper() { EpisodeId = episode.EpisodeId, AudioStreamId = entry.AudioStreamId });
                }

                foreach (var stream in episode.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    await database.EpisodeSubtitleStreamMapper.InsertOrUpdateAsync(new EpisodeSubtitleStreamMapper() { EpisodeId = episode.EpisodeId, SubtitleStreamId = entry.SubtitleStreamId });
                }
                foreach (var stream in episode.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    await database.EpisodeVideoStreamMapper.InsertOrUpdateAsync(new EpisodeVideoStreamMapper() { EpisodeId = episode.EpisodeId, VideoStreamId = entry.VideoStreamId });
                }
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveMusicVideos(List<MusicVideo> musicvideos) {
            foreach (MusicVideo musicvideo in musicvideos) {
                Debug.WriteLine("Save MusicVideo with id: " + musicvideo.MusicVideoId);
                var musicVideoEntry = new MusicVideoTableEntry(musicvideo);
                var result = await database.MusicVideos.InsertOrUpdateAsync(musicVideoEntry);
                if (result == InsertOrUpdate.Update) {
                    await database.MusicVideoArtistMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                    await database.MusicVideoAudioStreamMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                    await database.MusicVideoDirectorMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                    await database.MusicVideoGenreMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                    await database.MusicVideoSubtitleStreamMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                    await database.MusicVideoVideoStreamMapper.RemoveAllAsync(x => x.MusicVideoId == musicvideo.MusicVideoId);
                }

                foreach (string artist in musicvideo.Artist) {
                    var entry = new MusicVideoArtistTableEntry(artist);
                    await database.MusicVideoArtists.InsertOrUpdateAsync(entry);

                    await database.MusicVideoArtistMapper.InsertOrUpdateAsync(new MusicVideoArtistMapper() { MusicVideoArtistId = entry.MusicVideoArtistId, MusicVideoId = musicvideo.MusicVideoId });
                }

                foreach (string genre in musicvideo.Genre) {
                    var entry = new MusicVideoGenreTableEntry(genre);
                    await database.MusicVideoGenres.InsertOrUpdateAsync(entry);
                    await database.MusicVideoGenreMapper.InsertOrUpdateAsync(new MusicVideoGenreMapper() { MusicVideoId = musicvideo.MusicVideoId, GenreId = entry.GenreId });
                }

                foreach (string director in musicvideo.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    await database.MusicVideoDirectorMapper.InsertOrUpdateAsync(new MusicVideoDirectorMapper() { DirectorId = entry.DirectorId, MusicVideoId = musicvideo.MusicVideoId });
                }

                foreach (var stream in musicvideo.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    await database.MusicVideoAudioStreamMapper.InsertOrUpdateAsync(new MusicVideoAudioStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, AudioStreamId = entry.AudioStreamId });
                }

                foreach (var stream in musicvideo.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    await database.MusicVideoSubtitleStreamMapper.InsertOrUpdateAsync(new MusicVideoSubtitleStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, SubtitleStreamId = entry.SubtitleStreamId });
                }
                foreach (var stream in musicvideo.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    await database.MusicVideoVideoStreamMapper.InsertOrUpdateAsync(new MusicVideoVideoStreamMapper() { MusicVideoId = musicvideo.MusicVideoId, VideoStreamId = entry.VideoStreamId });
                }
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveMovieSets(List<MovieSet> moviesets) {
            foreach (MovieSet movieset in moviesets) {
                Debug.WriteLine("Save MovieSet with id: " + movieset.SetId);
                var entry = new MovieSetTableEntry(movieset);
                var result = await database.MovieSets.InsertOrUpdateAsync(entry);
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveMovies(List<Movie> movies) {
            foreach (Movie movie in movies) {
                Debug.WriteLine("Save Movie with id: " + movie.MovieId);
                var movieEntry = new MovieTableEntry(movie);
                var result = await database.Movies.InsertOrUpdateAsync(movieEntry);
                if(result == InsertOrUpdate.Update) {
                    await database.MovieActorMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieAudioStreamMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieDirectorMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieGenreMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieSubtitleStreamMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieVideoStreamMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                    await database.MovieSetMapper.RemoveAllAsync(x => x.MovieId == movie.MovieId);
                }
                if (movie.SetId != 0) {
                    await database.MovieSetMapper.InsertOrUpdateAsync(new MovieSetMapper() { MovieId = movie.MovieId, MovieSetId = movie.SetId });
                }
                
                foreach (string genre in movie.Genre) {
                    var entry = new MovieGenreTableEntry(genre);
                    await database.MovieGenres.InsertOrUpdateAsync(entry);
                    await database.MovieGenreMapper.InsertOrUpdateAsync(new MovieGenreMapper() { MovieId = movie.MovieId, GenreId = entry.GenreId });
                }

                foreach (Actor actor in movie.Cast) {
                    var entry = new ActorTableEntry(actor);
                    await database.Actors.InsertOrUpdateAsync(entry);

                    await database.MovieActorMapper.InsertOrUpdateAsync(new MovieActorMapper() { ActorId = entry.ActorId, MovieId = movie.MovieId, Role = actor.Role });
                }

                foreach (string director in movie.Director) {
                    var entry = new DirectorTableEntry(director);
                    await database.Directors.InsertOrUpdateAsync(entry);

                    await database.MovieDirectorMapper.InsertOrUpdateAsync(new MovieDirectorMapper() { DirectorId = entry.DirectorId, MovieId = movie.MovieId });
                }

                foreach (var stream in movie.StreamDetails.Audio) {
                    var entry = new AudioStreamTableEntry(stream);
                    await database.AudioStreams.InsertOrUpdateAsync(entry);

                    await database.MovieAudioStreamMapper.InsertOrUpdateAsync(new MovieAudioStreamMapper() { MovieId = movie.MovieId, AudioStreamId = entry.AudioStreamId });
                }

                foreach (var stream in movie.StreamDetails.Subtitle) {
                    var entry = new SubtitleStreamTableEntry(stream);
                    await database.SubtitleStreams.InsertOrUpdateAsync(entry);

                    await database.MovieSubtitleStreamMapper.InsertOrUpdateAsync(new MovieSubtitleStreamMapper() { MovieId = movie.MovieId, SubtitleStreamId = entry.SubtitleStreamId });
                }
                foreach (var stream in movie.StreamDetails.Video) {
                    var entry = new VideoStreamTableEntry(stream);
                    await database.VideoStreams.InsertOrUpdateAsync(entry);

                    await database.MovieVideoStreamMapper.InsertOrUpdateAsync(new MovieVideoStreamMapper() { MovieId = movie.MovieId, VideoStreamId = entry.VideoStreamId });
                }
            }
            await database.SaveChangesAsync();
        }
    }
}
