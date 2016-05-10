using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KodiRemote.Migrations.Settings
{
    public partial class InitSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kodis",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AlbumCount = table.Column<int>(nullable: false),
                    ArtistCount = table.Column<int>(nullable: false),
                    EpisodeCount = table.Column<int>(nullable: false),
                    Hostname = table.Column<string>(nullable: true),
                    JSONMajor = table.Column<int>(nullable: false),
                    JSONMinor = table.Column<int>(nullable: false),
                    JSONPatch = table.Column<int>(nullable: false),
                    KodiMajor = table.Column<int>(nullable: false),
                    KodiMinor = table.Column<int>(nullable: false),
                    KodiName = table.Column<string>(nullable: true),
                    KodiRevision = table.Column<string>(nullable: true),
                    KodiTag = table.Column<string>(nullable: true),
                    MovieCount = table.Column<int>(nullable: false),
                    MovieSetCount = table.Column<int>(nullable: false),
                    MusicVideoCount = table.Column<int>(nullable: false),
                    Port = table.Column<string>(nullable: true),
                    SkinName = table.Column<string>(nullable: true),
                    SongCount = table.Column<int>(nullable: false),
                    TVShowCount = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KodiSettings", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Kodis");
        }
    }
}
