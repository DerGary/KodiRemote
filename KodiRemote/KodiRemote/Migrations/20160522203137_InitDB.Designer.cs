using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KodiRemote.Code.Database;

namespace KodiRemote.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20160522203137_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("KodiRemote.Code.Database.AddonTables.AddonTableEntry", b =>
                {
                    b.Property<string>("AddonId");

                    b.Property<string>("Author");

                    b.Property<bool>("Broken");

                    b.Property<string>("Description");

                    b.Property<string>("Disclaimer");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Fanart");

                    b.Property<string>("Name");

                    b.Property<float>("Rating");

                    b.Property<string>("Summary");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Type");

                    b.Property<string>("Version");

                    b.HasKey("AddonId");

                    b.HasAnnotation("Relational:TableName", "Addons");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeActorMapper", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("ActorId");

                    b.Property<string>("Role");

                    b.HasKey("EpisodeId", "ActorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeAudioStreamMapper", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("AudioStreamId");

                    b.HasKey("EpisodeId", "AudioStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeDirectorMapper", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("DirectorId");

                    b.HasKey("EpisodeId", "DirectorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeSubtitleStreamMapper", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("SubtitleStreamId");

                    b.HasKey("EpisodeId", "SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DateAdded");

                    b.Property<int>("Episode");

                    b.Property<int>("PlayCount");

                    b.Property<string>("Plot");

                    b.Property<float>("Rating");

                    b.Property<int>("Runtime");

                    b.Property<int>("Season");

                    b.Property<int>("TVShowId");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.HasKey("EpisodeId");

                    b.HasAnnotation("Relational:TableName", "Episodes");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeVideoStreamMapper", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("VideoStreamId");

                    b.HasKey("EpisodeId", "VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.ActorTableEntry", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<string>("Name");

                    b.Property<string>("Thumbnail");

                    b.HasKey("ActorId");

                    b.HasAnnotation("Relational:TableName", "Actors");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.AudioStreamTableEntry", b =>
                {
                    b.Property<int>("AudioStreamId");

                    b.Property<int>("Channels");

                    b.Property<string>("Codec");

                    b.Property<string>("Language");

                    b.HasKey("AudioStreamId");

                    b.HasAnnotation("Relational:TableName", "AudioStreams");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.DirectorTableEntry", b =>
                {
                    b.Property<int>("DirectorId");

                    b.Property<string>("Name");

                    b.HasKey("DirectorId");

                    b.HasAnnotation("Relational:TableName", "Directors");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.SubtitleStreamTableEntry", b =>
                {
                    b.Property<int>("SubtitleStreamId");

                    b.Property<string>("Language");

                    b.HasKey("SubtitleStreamId");

                    b.HasAnnotation("Relational:TableName", "SubtitleStreams");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.VideoStreamTableEntry", b =>
                {
                    b.Property<int>("VideoStreamId");

                    b.Property<float>("Aspect");

                    b.Property<string>("Codec");

                    b.Property<int>("Height");

                    b.Property<int>("Width");

                    b.HasKey("VideoStreamId");

                    b.HasAnnotation("Relational:TableName", "VideoStreams");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieActorMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("ActorId");

                    b.Property<string>("Role");

                    b.HasKey("MovieId", "ActorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieAudioStreamMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("AudioStreamId");

                    b.HasKey("MovieId", "AudioStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieDirectorMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("DirectorId");

                    b.HasKey("MovieId", "DirectorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieGenreMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("GenreId");

                    b.HasKey("MovieId", "GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieGenreTableEntry", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.HasKey("GenreId");

                    b.HasAlternateKey("Genre")
                        .HasAnnotation("Relational:Name", "AK_string_Genre");

                    b.HasAnnotation("Relational:TableName", "MovieGenres");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieMovieSetMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("MovieSetId");

                    b.HasKey("MovieId", "MovieSetId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieSetTableEntry", b =>
                {
                    b.Property<int>("SetId");

                    b.Property<string>("Fanart");

                    b.Property<string>("Label");

                    b.Property<int>("PlayCount");

                    b.Property<string>("Poster");

                    b.Property<string>("Thumbnail");

                    b.HasKey("SetId");

                    b.HasAnnotation("Relational:TableName", "MovieSets");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieSubtitleStreamMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("SubtitleStreamId");

                    b.HasKey("MovieId", "SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieTableEntry", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<string>("DateAdded");

                    b.Property<string>("Fanart");

                    b.Property<string>("IMDBNumber");

                    b.Property<string>("Label");

                    b.Property<int>("PlayCount");

                    b.Property<string>("Plot");

                    b.Property<string>("Poster");

                    b.Property<float>("Rating");

                    b.Property<int>("Runtime");

                    b.Property<int>("SetId");

                    b.Property<string>("Trailer");

                    b.Property<int>("Year");

                    b.HasKey("MovieId");

                    b.HasAnnotation("Relational:TableName", "Movies");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieVideoStreamMapper", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("VideoStreamId");

                    b.HasKey("MovieId", "VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.AlbumArtistMapper", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.HasKey("AlbumId", "ArtistId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.AlbumGenreMapper", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("GenreId");

                    b.HasKey("AlbumId", "GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.AlbumTableEntry", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<string>("AlbumLabel");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayArtist");

                    b.Property<string>("Fanart");

                    b.Property<string>("Label");

                    b.Property<int>("PlayCount");

                    b.Property<float>("Rating");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<int>("Year");

                    b.HasKey("AlbumId");

                    b.HasAnnotation("Relational:TableName", "Albums");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.ArtistTableEntry", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<string>("Artist");

                    b.Property<string>("Born");

                    b.Property<string>("Description");

                    b.Property<string>("Died");

                    b.Property<string>("Fanart");

                    b.Property<string>("Formed");

                    b.Property<string>("Label");

                    b.Property<string>("Thumbnail");

                    b.HasKey("ArtistId");

                    b.HasAnnotation("Relational:TableName", "Artists");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.MusicGenreTableEntry", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.HasKey("GenreId");

                    b.HasAlternateKey("Genre")
                        .HasAnnotation("Relational:Name", "AK_string_Genre");

                    b.HasAnnotation("Relational:TableName", "MusicGenres");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.MusicPlaylistSongMapper", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("PlaylistId");

                    b.HasKey("SongId", "PlaylistId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.MusicPlaylistTableEntry", b =>
                {
                    b.Property<int>("PlaylistId");

                    b.HasKey("PlaylistId");

                    b.HasAnnotation("Relational:TableName", "MusicPlaylists");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongAlbumMapper", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("AlbumId");

                    b.HasKey("SongId", "AlbumId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongArtistMapper", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("ArtistId");

                    b.HasKey("SongId", "ArtistId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongGenreMapper", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("GenreId");

                    b.HasKey("SongId", "GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongTableEntry", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Album");

                    b.Property<int>("AlbumId");

                    b.Property<string>("Comment");

                    b.Property<string>("DisplayArtist");

                    b.Property<int>("Duration");

                    b.Property<string>("Fanart");

                    b.Property<string>("Label");

                    b.Property<int>("PlayCount");

                    b.Property<float>("Rating");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<int>("Track");

                    b.Property<int>("Year");

                    b.HasKey("SongId");

                    b.HasAnnotation("Relational:TableName", "Songs");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoArtistMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("MusicVideoArtistId");

                    b.HasKey("MusicVideoId", "MusicVideoArtistId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoArtistTableEntry", b =>
                {
                    b.Property<int>("MusicVideoArtistId");

                    b.Property<string>("Name");

                    b.HasKey("MusicVideoArtistId");

                    b.HasAlternateKey("Name")
                        .HasAnnotation("Relational:Name", "AK_string_Name");

                    b.HasAnnotation("Relational:TableName", "MusicVideoArtists");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoAudioStreamMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("AudioStreamId");

                    b.HasKey("MusicVideoId", "AudioStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoDirectorMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("DirectorId");

                    b.HasKey("MusicVideoId", "DirectorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoGenreMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("GenreId");

                    b.HasKey("MusicVideoId", "GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoGenreTableEntry", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.HasKey("GenreId");

                    b.HasAlternateKey("Genre")
                        .HasAnnotation("Relational:Name", "AK_string_Genre");

                    b.HasAnnotation("Relational:TableName", "MusicVideoGenres");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoSubtitleStreamMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("SubtitleStreamId");

                    b.HasKey("MusicVideoId", "SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<string>("Album");

                    b.Property<string>("DateAdded");

                    b.Property<string>("Fanart");

                    b.Property<string>("Label");

                    b.Property<int>("PlayCount");

                    b.Property<string>("Plot");

                    b.Property<string>("Poster");

                    b.Property<int>("Runtime");

                    b.Property<string>("Thumbnail");

                    b.Property<int>("Track");

                    b.Property<int>("Year");

                    b.HasKey("MusicVideoId");

                    b.HasAnnotation("Relational:TableName", "MusicVideos");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoVideoStreamMapper", b =>
                {
                    b.Property<int>("MusicVideoId");

                    b.Property<int>("VideoStreamId");

                    b.HasKey("MusicVideoId", "VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowActorMapper", b =>
                {
                    b.Property<int>("TVShowId");

                    b.Property<int>("ActorId");

                    b.Property<string>("Role");

                    b.HasKey("TVShowId", "ActorId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowGenreMapper", b =>
                {
                    b.Property<int>("TVShowId");

                    b.Property<int>("GenreId");

                    b.HasKey("TVShowId", "GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowGenreTableEntry", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.HasKey("GenreId");

                    b.HasAlternateKey("Genre")
                        .HasAnnotation("Relational:Name", "AK_string_Genre");

                    b.HasAnnotation("Relational:TableName", "TVShowGenres");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowSeasonTableEntry", b =>
                {
                    b.Property<int>("TVShowId");

                    b.Property<int>("Season");

                    b.Property<string>("Banner");

                    b.Property<int>("Episode");

                    b.Property<string>("Label");

                    b.Property<string>("Poster");

                    b.Property<int>("WatchedEpisodes");

                    b.HasKey("TVShowId", "Season");

                    b.HasAnnotation("Relational:TableName", "TVShowSeasons");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowTableEntry", b =>
                {
                    b.Property<int>("TVShowId");

                    b.Property<string>("Banner");

                    b.Property<string>("DateAdded");

                    b.Property<int>("Episode");

                    b.Property<string>("Fanart");

                    b.Property<string>("IMDBNumber");

                    b.Property<string>("Label");

                    b.Property<string>("Plot");

                    b.Property<string>("Poster");

                    b.Property<float>("Rating");

                    b.Property<int>("WatchedEpisodes");

                    b.HasKey("TVShowId");

                    b.HasAnnotation("Relational:TableName", "TVShows");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeActorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.ActorTableEntry")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry")
                        .WithMany()
                        .HasForeignKey("EpisodeId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeAudioStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.AudioStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("AudioStreamId");

                    b.HasOne("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry")
                        .WithMany()
                        .HasForeignKey("EpisodeId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeDirectorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.DirectorTableEntry")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry")
                        .WithMany()
                        .HasForeignKey("EpisodeId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeSubtitleStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry")
                        .WithMany()
                        .HasForeignKey("EpisodeId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.SubtitleStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowSeasonTableEntry")
                        .WithMany()
                        .HasForeignKey("TVShowId", "Season");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.EpisodeTables.EpisodeVideoStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.EpisodeTables.EpisodeTableEntry")
                        .WithMany()
                        .HasForeignKey("EpisodeId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.VideoStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieActorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.ActorTableEntry")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieAudioStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.AudioStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("AudioStreamId");

                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieDirectorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.DirectorTableEntry")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieGenreMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieGenreTableEntry")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieMovieSetMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieSetTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieSetId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieSubtitleStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.SubtitleStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MovieTables.MovieVideoStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MovieTables.MovieTableEntry")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.VideoStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.AlbumArtistMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.AlbumTableEntry")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.ArtistTableEntry")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.AlbumGenreMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.AlbumTableEntry")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.MusicGenreTableEntry")
                        .WithMany()
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.MusicPlaylistSongMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.SongTableEntry")
                        .WithMany()
                        .HasForeignKey("PlaylistId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.MusicPlaylistTableEntry")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongAlbumMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.SongTableEntry")
                        .WithMany()
                        .HasForeignKey("AlbumId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.AlbumTableEntry")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongArtistMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.ArtistTableEntry")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.SongTableEntry")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicTables.SongGenreMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicTables.MusicGenreTableEntry")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("KodiRemote.Code.Database.MusicTables.SongTableEntry")
                        .WithMany()
                        .HasForeignKey("SongId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoArtistMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoArtistTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoArtistId");

                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoAudioStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.AudioStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("AudioStreamId");

                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoDirectorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.DirectorTableEntry")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoGenreMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoGenreTableEntry")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoSubtitleStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.SubtitleStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("SubtitleStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.MusicVideoTables.MusicVideoVideoStreamMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.MusicVideoTables.MusicVideoTableEntry")
                        .WithMany()
                        .HasForeignKey("MusicVideoId");

                    b.HasOne("KodiRemote.Code.Database.GeneralTables.VideoStreamTableEntry")
                        .WithMany()
                        .HasForeignKey("VideoStreamId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowActorMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.GeneralTables.ActorTableEntry")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowTableEntry")
                        .WithMany()
                        .HasForeignKey("TVShowId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowGenreMapper", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowGenreTableEntry")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowTableEntry")
                        .WithMany()
                        .HasForeignKey("TVShowId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowSeasonTableEntry", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowTableEntry")
                        .WithMany()
                        .HasForeignKey("TVShowId");
                });
        }
    }
}
