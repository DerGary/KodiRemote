using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Utils;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseContextWrapper {
        private string name;

        public DatabaseWrapper<ActorTableEntry> Actors { get; set; }
        public DatabaseWrapper<AudioStreamTableEntry> AudioStreams { get; set; }
        public DatabaseWrapper<DirectorTableEntry> Directors { get; set; }
        public DatabaseWrapper<SubtitleStreamTableEntry> SubtitleStreams { get; set; }
        public DatabaseWrapper<VideoStreamTableEntry> VideoStreams { get; set; }
               
        public DatabaseWrapper<TVShowTableEntry> TVShows { get; set; }
        public DatabaseWrapper<TVShowGenreTableEntry> TVShowGenres { get; set; }
        public DatabaseWrapper<TVShowSeasonTableEntry> TVShowSeasons { get; set; }
        public DatabaseWrapper<TVShowGenreMapper> TVShowGenreMapper { get; set; }
        public DatabaseWrapper<TVShowActorMapper> TVShowActorMapper { get; set; }
               
        public DatabaseWrapper<EpisodeTableEntry> Episodes { get; set; }
        public DatabaseWrapper<EpisodeActorMapper> EpisodeActorMapper { get; set; }
        public DatabaseWrapper<EpisodeAudioStreamMapper> EpisodeAudioStreamMapper { get; set; }
        public DatabaseWrapper<EpisodeDirectorMapper> EpisodeDirectorMapper { get; set; }
        public DatabaseWrapper<EpisodeSubtitleStreamMapper> EpisodeSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<EpisodeVideoStreamMapper> EpisodeVideoStreamMapper { get; set; }

        public DatabaseWrapper<MovieSetTableEntry> MovieSets { get; set; }
        public DatabaseWrapper<MovieMovieSetMapper> MovieMovieSetMapper { get; set; }
        public DatabaseWrapper<MovieTableEntry> Movies { get; set; }
        public DatabaseWrapper<MovieActorMapper> MovieActorMapper { get; set; }
        public DatabaseWrapper<MovieAudioStreamMapper> MovieAudioStreamMapper { get; set; }
        public DatabaseWrapper<MovieDirectorMapper> MovieDirectorMapper { get; set; }
        public DatabaseWrapper<MovieSubtitleStreamMapper> MovieSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<MovieVideoStreamMapper> MovieVideoStreamMapper { get; set; }
        public DatabaseWrapper<MovieGenreMapper> MovieGenreMapper { get; set; }
        public DatabaseWrapper<MovieGenreTableEntry> MovieGenres { get; set; }
        
        public DatabaseWrapper<MusicVideoTableEntry> MusicVideos { get; set; }
        public DatabaseWrapper<MusicVideoArtistMapper> MusicVideoArtistMapper { get; set; }
        public DatabaseWrapper<MusicVideoArtistTableEntry> MusicVideoArtists { get; set; }
        public DatabaseWrapper<MusicVideoAudioStreamMapper> MusicVideoAudioStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoDirectorMapper> MusicVideoDirectorMapper { get; set; }
        public DatabaseWrapper<MusicVideoSubtitleStreamMapper> MusicVideoSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoVideoStreamMapper> MusicVideoVideoStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoGenreMapper> MusicVideoGenreMapper { get; set; }
        public DatabaseWrapper<MusicVideoGenreTableEntry> MusicVideoGenres { get; set; }


        public DatabaseWrapper<AlbumArtistMapper> AlbumArtistMapper { get; set; }
        public DatabaseWrapper<AlbumGenreMapper> AlbumGenreMapper { get; set; }
        public DatabaseWrapper<AlbumTableEntry> Albums { get; set; }
        public DatabaseWrapper<ArtistTableEntry> Artists { get; set; }
        public DatabaseWrapper<MusicGenreTableEntry> MusicGenres { get; set; }
        public DatabaseWrapper<MusicPlaylistSongMapper> MusicPlaylistSongMapper { get; set; }
        public DatabaseWrapper<MusicPlaylistTableEntry> MusicPlaylists { get; set; }
        public DatabaseWrapper<SongAlbumMapper> SongAlbumMapper { get; set; }
        public DatabaseWrapper<SongArtistMapper> SongArtistMapper { get; set; }
        public DatabaseWrapper<SongGenreMapper> SongGenreMapper { get; set; }
        public DatabaseWrapper<SongTableEntry> Songs { get; set; }

        public DatabaseWrapper<AddonTableEntry> Addons { get; set; }

        public DbContext CreateContext() {
            return new DatabaseContext(name);
        }

        public async Task Init(string name) {
            this.name = name;
            using (var context = CreateContext()) {
                //ILoggerFactory logger = ((IInfrastructure<IServiceProvider>)context).Instance.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
                //logger.AddProvider(new DatabaseLoggerProvider());
                await context.Database.MigrateAsync();
            }

            Actors = new DatabaseWrapper<ActorTableEntry>(CreateContext);
            AudioStreams = new DatabaseWrapper<AudioStreamTableEntry>(CreateContext);
            Directors = new DatabaseWrapper<DirectorTableEntry>(CreateContext);
            SubtitleStreams = new DatabaseWrapper<SubtitleStreamTableEntry>(CreateContext);
            VideoStreams = new DatabaseWrapper<VideoStreamTableEntry>(CreateContext);

            TVShows = new DatabaseWrapper<TVShowTableEntry>(CreateContext);
            TVShowGenres = new DatabaseWrapper<TVShowGenreTableEntry>(CreateContext);
            TVShowSeasons = new DatabaseWrapper<TVShowSeasonTableEntry>(CreateContext);
            TVShowGenreMapper = new DatabaseWrapper<TVShowGenreMapper>(CreateContext);
            TVShowActorMapper = new DatabaseWrapper<TVShowActorMapper>(CreateContext);

            Episodes = new DatabaseWrapper<EpisodeTableEntry>(CreateContext);
            EpisodeActorMapper = new DatabaseWrapper<EpisodeActorMapper>(CreateContext);
            EpisodeAudioStreamMapper = new DatabaseWrapper<EpisodeAudioStreamMapper>(CreateContext);
            EpisodeDirectorMapper = new DatabaseWrapper<EpisodeDirectorMapper>(CreateContext);
            EpisodeSubtitleStreamMapper = new DatabaseWrapper<EpisodeSubtitleStreamMapper>(CreateContext);
            EpisodeVideoStreamMapper = new DatabaseWrapper<EpisodeVideoStreamMapper>(CreateContext);

            Movies = new DatabaseWrapper<MovieTableEntry>(CreateContext);
            MovieSets = new DatabaseWrapper<MovieSetTableEntry>(CreateContext);
            MovieMovieSetMapper = new DatabaseWrapper<MovieMovieSetMapper>(CreateContext);
            MovieActorMapper = new DatabaseWrapper<MovieActorMapper>(CreateContext);
            MovieAudioStreamMapper = new DatabaseWrapper<MovieAudioStreamMapper>(CreateContext);
            MovieDirectorMapper = new DatabaseWrapper<MovieDirectorMapper>(CreateContext);
            MovieSubtitleStreamMapper = new DatabaseWrapper<MovieSubtitleStreamMapper>(CreateContext);
            MovieVideoStreamMapper = new DatabaseWrapper<MovieVideoStreamMapper>(CreateContext);
            MovieGenreMapper = new DatabaseWrapper<MovieGenreMapper>(CreateContext);
            MovieGenres = new DatabaseWrapper<MovieGenreTableEntry>(CreateContext);

            MusicVideoArtistMapper = new DatabaseWrapper<MusicVideoArtistMapper>(CreateContext);
            MusicVideoArtists = new DatabaseWrapper<MusicVideoArtistTableEntry>(CreateContext);
            MusicVideoAudioStreamMapper = new DatabaseWrapper<MusicVideoAudioStreamMapper>(CreateContext);
            MusicVideoDirectorMapper = new DatabaseWrapper<MusicVideoDirectorMapper>(CreateContext);
            MusicVideoGenreMapper = new DatabaseWrapper<MusicVideoGenreMapper>(CreateContext);
            MusicVideoGenres = new DatabaseWrapper<MusicVideoGenreTableEntry>(CreateContext);
            MusicVideos = new DatabaseWrapper<MusicVideoTableEntry>(CreateContext);
            MusicVideoSubtitleStreamMapper = new DatabaseWrapper<MusicVideoSubtitleStreamMapper>(CreateContext);
            MusicVideoVideoStreamMapper = new DatabaseWrapper<MusicVideoVideoStreamMapper>(CreateContext);

            AlbumArtistMapper = new DatabaseWrapper<AlbumArtistMapper>(CreateContext);
            AlbumGenreMapper = new DatabaseWrapper<AlbumGenreMapper>(CreateContext);
            Albums = new DatabaseWrapper<AlbumTableEntry>(CreateContext);
            Artists = new DatabaseWrapper<ArtistTableEntry>(CreateContext);
            MusicGenres = new DatabaseWrapper<MusicGenreTableEntry>(CreateContext);
            MusicPlaylistSongMapper = new DatabaseWrapper<MusicPlaylistSongMapper>(CreateContext);
            MusicPlaylists = new DatabaseWrapper<MusicPlaylistTableEntry>(CreateContext);
            SongAlbumMapper = new DatabaseWrapper<SongAlbumMapper>(CreateContext);
            SongArtistMapper = new DatabaseWrapper<SongArtistMapper>(CreateContext);
            SongGenreMapper = new DatabaseWrapper<SongGenreMapper>(CreateContext);
            Songs = new DatabaseWrapper<SongTableEntry>(CreateContext);

            Addons = new DatabaseWrapper<AddonTableEntry>(CreateContext);
        }

        public async Task SaveChangesAsync() {
            await Actors.SaveChangesAsync();
            await AudioStreams.SaveChangesAsync();
            await Directors.SaveChangesAsync();
            await SubtitleStreams.SaveChangesAsync();
            await VideoStreams.SaveChangesAsync();

            await TVShows.SaveChangesAsync();
            await TVShowGenres.SaveChangesAsync();
            await TVShowSeasons.SaveChangesAsync();
            await TVShowGenreMapper.SaveChangesAsync();
            await TVShowActorMapper.SaveChangesAsync();

            await Episodes.SaveChangesAsync();
            await EpisodeActorMapper.SaveChangesAsync();
            await EpisodeAudioStreamMapper.SaveChangesAsync();
            await EpisodeDirectorMapper.SaveChangesAsync();
            await EpisodeSubtitleStreamMapper.SaveChangesAsync();
            await EpisodeVideoStreamMapper.SaveChangesAsync();

            await MovieSets.SaveChangesAsync();
            await Movies.SaveChangesAsync();
            await MovieGenres.SaveChangesAsync();
            await MovieMovieSetMapper.SaveChangesAsync();
            await MovieGenreMapper.SaveChangesAsync();
            await MovieActorMapper.SaveChangesAsync();
            await MovieAudioStreamMapper.SaveChangesAsync();
            await MovieDirectorMapper.SaveChangesAsync();
            await MovieSubtitleStreamMapper.SaveChangesAsync();
            await MovieVideoStreamMapper.SaveChangesAsync();

            await MusicVideos.SaveChangesAsync();
            await MusicVideoArtists.SaveChangesAsync();
            await MusicVideoGenres.SaveChangesAsync();
            await MusicVideoArtistMapper.SaveChangesAsync();
            await MusicVideoAudioStreamMapper.SaveChangesAsync();
            await MusicVideoDirectorMapper.SaveChangesAsync();
            await MusicVideoGenreMapper.SaveChangesAsync();
            await MusicVideoSubtitleStreamMapper.SaveChangesAsync();
            await MusicVideoVideoStreamMapper.SaveChangesAsync();

            await Songs.SaveChangesAsync();
            await Albums.SaveChangesAsync();
            await Artists.SaveChangesAsync();
            await MusicGenres.SaveChangesAsync();
            await MusicPlaylists.SaveChangesAsync();
            await AlbumArtistMapper.SaveChangesAsync();
            await AlbumGenreMapper.SaveChangesAsync();
            await MusicPlaylistSongMapper.SaveChangesAsync();
            await SongAlbumMapper.SaveChangesAsync();
            await SongArtistMapper.SaveChangesAsync();
            await SongGenreMapper.SaveChangesAsync();

            await Addons.SaveChangesAsync();
        }
    }
}
