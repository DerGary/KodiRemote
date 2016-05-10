using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KodiRemote.Code.Database;

namespace KodiRemote.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20160510205208_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

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
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Thumbnail");

                    b.HasKey("ActorId");

                    b.HasAnnotation("Relational:TableName", "Actors");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.AudioStreamTableEntry", b =>
                {
                    b.Property<int>("AudioStreamId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Channels");

                    b.Property<string>("Codec");

                    b.Property<string>("Language");

                    b.HasKey("AudioStreamId");

                    b.HasAnnotation("Relational:TableName", "AudioStreams");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.DirectorTableEntry", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DirectorId");

                    b.HasAnnotation("Relational:TableName", "Directors");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.SubtitleStreamTableEntry", b =>
                {
                    b.Property<int>("SubtitleStreamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language");

                    b.HasKey("SubtitleStreamId");

                    b.HasAnnotation("Relational:TableName", "SubtitleStreams");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.GeneralTables.VideoStreamTableEntry", b =>
                {
                    b.Property<int>("VideoStreamId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Aspect");

                    b.Property<string>("Codec");

                    b.Property<int>("Height");

                    b.Property<int>("Width");

                    b.HasKey("VideoStreamId");

                    b.HasAnnotation("Relational:TableName", "VideoStreams");
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
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd();

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
