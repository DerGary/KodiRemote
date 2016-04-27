using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseConnection {
        private SQLiteAsyncConnection connection;

        public async Task Init(KodiSettings settings) {
            connection = new SQLiteAsyncConnection(settings.Name);
            await connection.CreateTablesAsync(
                CreateFlags.None,
                typeof(TVShowTableEntry),
                typeof(TVShowSeasonTableEntry),
                typeof(TVShowGenreTableEntry),
                typeof(TVShowActorsTableEntry),
                
                typeof(MusicVideoArtistTableEntry),
                typeof(MusicVideoAudioStreamTableEntry),
                typeof(MusicVideoDirectorTableEntry),
                typeof(MusicVideoGenreTableEntry),
                typeof(MusicVideoSubtitleStreamTableEntry),
                typeof(MusicVideoTableEntry),
                typeof(MusicVideoVideoStreamTableEntry),
                typeof(MVArtistTableEntry),
                
                typeof(SongTableEntry),
                typeof(SongGenreTableEntry),
                typeof(SongArtistTableEntry),
                
                typeof(AudioPlaylistTableEntry),
                typeof(AudioPlaylistSongTableEntry),
                
                typeof(ArtistTableEntry),
                
                typeof(AlbumTableEntry),
                typeof(AlbumGenreTableEntry),
                typeof(AlbumArtistTableEntry),
                
                typeof(MovieActorTableEntry),
                typeof(MovieAudioStreamTableEntry),
                typeof(MovieDirectorTableEntry),
                typeof(MovieGenreTableEntry),
                typeof(MovieSetMovieTableEntry),
                typeof(MovieSetTableEntry),
                typeof(MovieSubtitleStreamTableEntry),
                typeof(MovieTableEntry),
                
                typeof(ActorsTableEntry),
                typeof(AudioStreamTableEntry),
                typeof(DirectorsTableEntry),
                typeof(GenreTableEntry),
                typeof(SubtitleStreamTableEntry),
                typeof(VideoStreamTableEntry),

                typeof(EpisodeActorTableEntry),
                typeof(EpisodeAudioStreamTableEntry),
                typeof(EpisodeDirectorTableEntry),
                typeof(EpisodeSubtitleStreamTableEntry),
                typeof(EpisodeTableEntry),
                typeof(EpisodeVideoStreamTableEntry),

                typeof(AddonTableEntry)
            );
        }
    }
}
