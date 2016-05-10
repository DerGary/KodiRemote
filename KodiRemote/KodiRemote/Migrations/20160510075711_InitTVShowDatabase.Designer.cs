using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using KodiRemote.Code.Database;

namespace KodiRemote.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20160510075711_InitTVShowDatabase")]
    partial class InitTVShowDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowActorsTableEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.Property<int>("TVShowId");

                    b.Property<string>("Thumbnail");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "TVShowActors");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowGenre", b =>
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

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowActorsTableEntry", b =>
                {
                    b.HasOne("KodiRemote.Code.Database.TVShowTables.TVShowTableEntry")
                        .WithMany()
                        .HasForeignKey("TVShowId");
                });

            modelBuilder.Entity("KodiRemote.Code.Database.TVShowTables.TVShowGenre", b =>
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
