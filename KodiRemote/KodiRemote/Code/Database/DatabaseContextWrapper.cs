using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseContextWrapper {
        private string name;

        public DbSetWrapper<ActorTableEntry> Actors { get; set; }
        public DbSetWrapper<AudioStreamTableEntry> AudioStreams { get; set; }
        public DbSetWrapper<DirectorTableEntry> Directors { get; set; }
        public DbSetWrapper<SubtitleStreamTableEntry> SubtitleStreams { get; set; }
        public DbSetWrapper<VideoStreamTableEntry> VideoStreams { get; set; }
               
        public DbSetWrapper<TVShowTableEntry> TVShows { get; set; }
        public DbSetWrapper<TVShowGenreTableEntry> TVShowGenres { get; set; }
        public DbSetWrapper<TVShowSeasonTableEntry> TVShowSeasons { get; set; }
        public DbSetWrapper<TVShowGenreMapper> TVShowGenreMapper { get; set; }
        public DbSetWrapper<TVShowActorMapper> TVShowActorMapper { get; set; }
               
        public DbSetWrapper<EpisodeTableEntry> Episodes { get; set; }
        public DbSetWrapper<EpisodeActorMapper> EpisodeActorMapper { get; set; }
        public DbSetWrapper<EpisodeAudioStreamMapper> EpisodeAudioStreamMapper { get; set; }
        public DbSetWrapper<EpisodeDirectorMapper> EpisodeDirectorMapper { get; set; }
        public DbSetWrapper<EpisodeSubtitleStreamMapper> EpisodeSubtitleStreamMapper { get; set; }
        public DbSetWrapper<EpisodeVideoStreamMapper> EpisodeVideoStreamMapper { get; set; }

        public DbSetWrapper<MovieSetTableEntry> MovieSets { get; set; }
        public DbSetWrapper<MovieMovieSetMapper> MovieMovieSetMapper { get; set; }
        public DbSetWrapper<MovieTableEntry> Movies { get; set; }
        public DbSetWrapper<MovieActorMapper> MovieActorMapper { get; set; }
        public DbSetWrapper<MovieAudioStreamMapper> MovieAudioStreamMapper { get; set; }
        public DbSetWrapper<MovieDirectorMapper> MovieDirectorMapper { get; set; }
        public DbSetWrapper<MovieSubtitleStreamMapper> MovieSubtitleStreamMapper { get; set; }
        public DbSetWrapper<MovieVideoStreamMapper> MovieVideoStreamMapper { get; set; }
        public DbSetWrapper<MovieGenreMapper> MovieGenreMapper { get; set; }
        public DbSetWrapper<MovieGenreTableEntry> MovieGenres { get; set; }
        
        public DbSetWrapper<MusicVideoTableEntry> MusicVideos { get; set; }
        public DbSetWrapper<MusicVideoArtistMapper> MusicVideoArtistMapper { get; set; }
        public DbSetWrapper<MusicVideoArtistTableEntry> MusicVideoArtists { get; set; }
        public DbSetWrapper<MusicVideoAudioStreamMapper> MusicVideoAudioStreamMapper { get; set; }
        public DbSetWrapper<MusicVideoDirectorMapper> MusicVideoDirectorMapper { get; set; }
        public DbSetWrapper<MusicVideoSubtitleStreamMapper> MusicVideoSubtitleStreamMapper { get; set; }
        public DbSetWrapper<MusicVideoVideoStreamMapper> MusicVideoVideoStreamMapper { get; set; }
        public DbSetWrapper<MusicVideoGenreMapper> MusicVideoGenreMapper { get; set; }
        public DbSetWrapper<MusicVideoGenreTableEntry> MusicVideoGenres { get; set; }


        public DbSetWrapper<AlbumArtistMapper> AlbumArtistMapper { get; set; }
        public DbSetWrapper<AlbumGenreMapper> AlbumGenreMapper { get; set; }
        public DbSetWrapper<AlbumTableEntry> Albums { get; set; }
        public DbSetWrapper<ArtistTableEntry> Artists { get; set; }
        public DbSetWrapper<MusicGenreTableEntry> MusicGenres { get; set; }
        public DbSetWrapper<MusicPlaylistSongMapper> MusicPlaylistSongMapper { get; set; }
        public DbSetWrapper<MusicPlaylistTableEntry> MusicPlaylists { get; set; }
        public DbSetWrapper<SongAlbumMapper> SongAlbumMapper { get; set; }
        public DbSetWrapper<SongArtistMapper> SongArtistMapper { get; set; }
        public DbSetWrapper<SongGenreMapper> SongGenreMapper { get; set; }
        public DbSetWrapper<SongTableEntry> Songs { get; set; }

        public DbSetWrapper<AddonTableEntry> Addons { get; set; }

        public DbContext CreateContext() {
            return new DatabaseContext(name);
        }

        public DatabaseContextWrapper(string name) {
            this.name = name;
            Actors = new DbSetWrapper<ActorTableEntry>(CreateContext);
            AudioStreams = new DbSetWrapper<AudioStreamTableEntry>(CreateContext);
            Directors = new DbSetWrapper<DirectorTableEntry>(CreateContext);
            SubtitleStreams = new DbSetWrapper<SubtitleStreamTableEntry>(CreateContext);
            VideoStreams = new DbSetWrapper<VideoStreamTableEntry>(CreateContext);

            TVShows = new DbSetWrapper<TVShowTableEntry>(CreateContext);
            TVShowGenres = new DbSetWrapper<TVShowGenreTableEntry>(CreateContext);
            TVShowSeasons = new DbSetWrapper<TVShowSeasonTableEntry>(CreateContext);
            TVShowGenreMapper = new DbSetWrapper<TVShowGenreMapper>(CreateContext);
            TVShowActorMapper = new DbSetWrapper<TVShowActorMapper>(CreateContext);

            Episodes = new DbSetWrapper<EpisodeTableEntry>(CreateContext);
            EpisodeActorMapper = new DbSetWrapper<EpisodeActorMapper>(CreateContext);
            EpisodeAudioStreamMapper = new DbSetWrapper<EpisodeAudioStreamMapper>(CreateContext);
            EpisodeDirectorMapper = new DbSetWrapper<EpisodeDirectorMapper>(CreateContext);
            EpisodeSubtitleStreamMapper = new DbSetWrapper<EpisodeSubtitleStreamMapper>(CreateContext);
            EpisodeVideoStreamMapper = new DbSetWrapper<EpisodeVideoStreamMapper>(CreateContext);

            Movies = new DbSetWrapper<MovieTableEntry>(CreateContext);
            MovieSets = new DbSetWrapper<MovieSetTableEntry>(CreateContext);
            MovieMovieSetMapper = new DbSetWrapper<MovieMovieSetMapper>(CreateContext);
            MovieActorMapper = new DbSetWrapper<MovieActorMapper>(CreateContext);
            MovieAudioStreamMapper = new DbSetWrapper<MovieAudioStreamMapper>(CreateContext);
            MovieDirectorMapper = new DbSetWrapper<MovieDirectorMapper>(CreateContext);
            MovieSubtitleStreamMapper = new DbSetWrapper<MovieSubtitleStreamMapper>(CreateContext);
            MovieVideoStreamMapper = new DbSetWrapper<MovieVideoStreamMapper>(CreateContext);
            MovieGenreMapper = new DbSetWrapper<MovieGenreMapper>(CreateContext);
            MovieGenres = new DbSetWrapper<MovieGenreTableEntry>(CreateContext);

            MusicVideoArtistMapper = new DbSetWrapper<MusicVideoArtistMapper>(CreateContext);
            MusicVideoArtists = new DbSetWrapper<MusicVideoArtistTableEntry>(CreateContext);
            MusicVideoAudioStreamMapper = new DbSetWrapper<MusicVideoAudioStreamMapper>(CreateContext);
            MusicVideoDirectorMapper = new DbSetWrapper<MusicVideoDirectorMapper>(CreateContext);
            MusicVideoGenreMapper = new DbSetWrapper<MusicVideoGenreMapper>(CreateContext);
            MusicVideoGenres = new DbSetWrapper<MusicVideoGenreTableEntry>(CreateContext);
            MusicVideos = new DbSetWrapper<MusicVideoTableEntry>(CreateContext);
            MusicVideoSubtitleStreamMapper = new DbSetWrapper<MusicVideoSubtitleStreamMapper>(CreateContext);
            MusicVideoVideoStreamMapper = new DbSetWrapper<MusicVideoVideoStreamMapper>(CreateContext);

            AlbumArtistMapper = new DbSetWrapper<AlbumArtistMapper>(CreateContext);
            AlbumGenreMapper = new DbSetWrapper<AlbumGenreMapper>(CreateContext);
            Albums = new DbSetWrapper<AlbumTableEntry>(CreateContext);
            Artists = new DbSetWrapper<ArtistTableEntry>(CreateContext);
            MusicGenres = new DbSetWrapper<MusicGenreTableEntry>(CreateContext);
            MusicPlaylistSongMapper = new DbSetWrapper<MusicPlaylistSongMapper>(CreateContext);
            MusicPlaylists = new DbSetWrapper<MusicPlaylistTableEntry>(CreateContext);
            SongAlbumMapper = new DbSetWrapper<SongAlbumMapper>(CreateContext);
            SongArtistMapper = new DbSetWrapper<SongArtistMapper>(CreateContext);
            SongGenreMapper = new DbSetWrapper<SongGenreMapper>(CreateContext);
            Songs = new DbSetWrapper<SongTableEntry>(CreateContext);

            Addons = new DbSetWrapper<AddonTableEntry>(CreateContext);
        }

        public async Task Init() {
            using (var context = CreateContext()) {
                ILoggerFactory logger = ((IInfrastructure<IServiceProvider>)context).Instance.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
                logger.AddProvider(new DatabaseLoggerProvider());
                await context.Database.MigrateAsync();
            }
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
