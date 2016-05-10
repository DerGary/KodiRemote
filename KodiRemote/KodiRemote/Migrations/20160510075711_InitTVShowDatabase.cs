using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KodiRemote.Migrations
{
    public partial class InitTVShowDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TVShowGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenreTableEntry", x => x.GenreId);
                    table.UniqueConstraint("AK_string_Genre", x => x.Genre);
                });
            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    Banner = table.Column<string>(nullable: true),
                    DateAdded = table.Column<string>(nullable: true),
                    Episode = table.Column<int>(nullable: false),
                    Fanart = table.Column<string>(nullable: true),
                    IMDBNumber = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    WatchedEpisodes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowTableEntry", x => x.TVShowId);
                });
            migrationBuilder.CreateTable(
                name: "TVShowActors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    TVShowId = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowActorsTableEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVShowActorsTableEntry_TVShowTableEntry_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TVShowGenre",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenre", x => new { x.TVShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TVShowGenre_TVShowGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "TVShowGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowGenre_TVShowTableEntry_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TVShowSeasons",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Banner = table.Column<string>(nullable: true),
                    Episode = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    WatchedEpisodes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowSeasonTableEntry", x => new { x.TVShowId, x.Season });
                    table.ForeignKey(
                        name: "FK_TVShowSeasonTableEntry_TVShowTableEntry_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("TVShowActors");
            migrationBuilder.DropTable("TVShowGenre");
            migrationBuilder.DropTable("TVShowSeasons");
            migrationBuilder.DropTable("TVShowGenres");
            migrationBuilder.DropTable("TVShows");
        }
    }
}
