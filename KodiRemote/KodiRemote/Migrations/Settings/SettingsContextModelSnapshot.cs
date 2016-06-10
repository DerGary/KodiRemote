using System;
using KodiRemote.Code.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KodiRemote.Migrations.Settings
{
    [DbContext(typeof(SettingsContext))]
    partial class SettingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("KodiRemote.Code.Essentials.KodiSettings", b =>
                {
                    b.Property<string>("Name");

                    b.Property<bool>("Active");

                    b.Property<int>("AlbumCount");

                    b.Property<int>("ArtistCount");

                    b.Property<int>("EpisodeCount");

                    b.Property<string>("Hostname");

                    b.Property<int>("JSONMajor");

                    b.Property<int>("JSONMinor");

                    b.Property<int>("JSONPatch");

                    b.Property<int>("KodiMajor");

                    b.Property<int>("KodiMinor");

                    b.Property<string>("KodiName");

                    b.Property<string>("KodiRevision");

                    b.Property<string>("KodiTag");

                    b.Property<int>("MovieCount");

                    b.Property<int>("MovieSetCount");

                    b.Property<int>("MusicVideoCount");

                    b.Property<string>("Password");

                    b.Property<string>("Port");

                    b.Property<string>("SkinName");

                    b.Property<int>("SongCount");

                    b.Property<int>("TVShowCount");

                    b.Property<int>("Type");

                    b.Property<string>("Username");

                    b.Property<string>("WebsocketPort");

                    b.HasKey("Name");

                    b.HasAnnotation("Relational:TableName", "Kodis");
                });
        }
    }
}
