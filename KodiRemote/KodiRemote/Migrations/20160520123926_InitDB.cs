using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KodiRemote.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTableEntry", x => x.ActorId);
                });
            migrationBuilder.CreateTable(
                name: "AudioStreams",
                columns: table => new
                {
                    AudioStreamId = table.Column<int>(nullable: false),
                    Channels = table.Column<int>(nullable: false),
                    Codec = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioStreamTableEntry", x => x.AudioStreamId);
                });
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorTableEntry", x => x.DirectorId);
                });
            migrationBuilder.CreateTable(
                name: "SubtitleStreams",
                columns: table => new
                {
                    SubtitleStreamId = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleStreamTableEntry", x => x.SubtitleStreamId);
                });
            migrationBuilder.CreateTable(
                name: "VideoStreams",
                columns: table => new
                {
                    VideoStreamId = table.Column<int>(nullable: false),
                    Aspect = table.Column<float>(nullable: false),
                    Codec = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStreamTableEntry", x => x.VideoStreamId);
                });
            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreTableEntry", x => x.GenreId);
                    table.UniqueConstraint("AK_string_Genre", x => x.Genre);
                });
            migrationBuilder.CreateTable(
                name: "MovieSets",
                columns: table => new
                {
                    SetId = table.Column<int>(nullable: false),
                    Fanart = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    PlayCount = table.Column<int>(nullable: false),
                    Poster = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSetTableEntry", x => x.SetId);
                });
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<string>(nullable: true),
                    Fanart = table.Column<string>(nullable: true),
                    IMDBNumber = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    PlayCount = table.Column<int>(nullable: false),
                    Plot = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Runtime = table.Column<int>(nullable: false),
                    SetId = table.Column<int>(nullable: false),
                    Trailer = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTableEntry", x => x.MovieId);
                });
            migrationBuilder.CreateTable(
                name: "TVShowGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
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
                name: "MovieActorMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActorMapper", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActorMapper_ActorTableEntry_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActorMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieAudioStreamMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    AudioStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieAudioStreamMapper", x => new { x.MovieId, x.AudioStreamId });
                    table.ForeignKey(
                        name: "FK_MovieAudioStreamMapper_AudioStreamTableEntry_AudioStreamId",
                        column: x => x.AudioStreamId,
                        principalTable: "AudioStreams",
                        principalColumn: "AudioStreamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieAudioStreamMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieDirectorMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectorMapper", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MovieDirectorMapper_DirectorTableEntry_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectorMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieGenreMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenreMapper", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenreMapper_MovieGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "MovieGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenreMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieSetMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    MovieSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSetMapper", x => new { x.MovieId, x.MovieSetId });
                    table.ForeignKey(
                        name: "FK_MovieSetMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSetMapper_MovieSetTableEntry_MovieSetId",
                        column: x => x.MovieSetId,
                        principalTable: "MovieSets",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieSubtitleStreamMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    SubtitleStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSubtitleStreamMapper", x => new { x.MovieId, x.SubtitleStreamId });
                    table.ForeignKey(
                        name: "FK_MovieSubtitleStreamMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSubtitleStreamMapper_SubtitleStreamTableEntry_SubtitleStreamId",
                        column: x => x.SubtitleStreamId,
                        principalTable: "SubtitleStreams",
                        principalColumn: "SubtitleStreamId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MovieVideoStreamMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    VideoStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVideoStreamMapper", x => new { x.MovieId, x.VideoStreamId });
                    table.ForeignKey(
                        name: "FK_MovieVideoStreamMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieVideoStreamMapper_VideoStreamTableEntry_VideoStreamId",
                        column: x => x.VideoStreamId,
                        principalTable: "VideoStreams",
                        principalColumn: "VideoStreamId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TVShowActorMapper",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowActorMapper", x => new { x.TVShowId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_TVShowActorMapper_ActorTableEntry_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowActorMapper_TVShowTableEntry_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "TVShowId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TVShowGenreMapper",
                columns: table => new
                {
                    TVShowId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenreMapper", x => new { x.TVShowId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_TVShowGenreMapper_TVShowGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "TVShowGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowGenreMapper_TVShowTableEntry_TVShowId",
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
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateAdded = table.Column<string>(nullable: true),
                    Episode = table.Column<int>(nullable: false),
                    PlayCount = table.Column<int>(nullable: false),
                    Plot = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Runtime = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    TVShowId = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeTableEntry", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_EpisodeTableEntry_TVShowSeasonTableEntry_TVShowId_Season",
                        columns: x => new { x.TVShowId, x.Season },
                        principalTable: "TVShowSeasons",
                        principalColumns: new[] { "TVShowId", "Season" },
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EpisodeActorMapper",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeActorMapper", x => new { x.EpisodeId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_EpisodeActorMapper_ActorTableEntry_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeActorMapper_EpisodeTableEntry_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EpisodeAudioStreamMapper",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    AudioStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeAudioStreamMapper", x => new { x.EpisodeId, x.AudioStreamId });
                    table.ForeignKey(
                        name: "FK_EpisodeAudioStreamMapper_AudioStreamTableEntry_AudioStreamId",
                        column: x => x.AudioStreamId,
                        principalTable: "AudioStreams",
                        principalColumn: "AudioStreamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeAudioStreamMapper_EpisodeTableEntry_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EpisodeDirectorMapper",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeDirectorMapper", x => new { x.EpisodeId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_EpisodeDirectorMapper_DirectorTableEntry_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeDirectorMapper_EpisodeTableEntry_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EpisodeSubtitleStreamMapper",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    SubtitleStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeSubtitleStreamMapper", x => new { x.EpisodeId, x.SubtitleStreamId });
                    table.ForeignKey(
                        name: "FK_EpisodeSubtitleStreamMapper_EpisodeTableEntry_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeSubtitleStreamMapper_SubtitleStreamTableEntry_SubtitleStreamId",
                        column: x => x.SubtitleStreamId,
                        principalTable: "SubtitleStreams",
                        principalColumn: "SubtitleStreamId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EpisodeVideoStreamMapper",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    VideoStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeVideoStreamMapper", x => new { x.EpisodeId, x.VideoStreamId });
                    table.ForeignKey(
                        name: "FK_EpisodeVideoStreamMapper_EpisodeTableEntry_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeVideoStreamMapper_VideoStreamTableEntry_VideoStreamId",
                        column: x => x.VideoStreamId,
                        principalTable: "VideoStreams",
                        principalColumn: "VideoStreamId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("EpisodeActorMapper");
            migrationBuilder.DropTable("EpisodeAudioStreamMapper");
            migrationBuilder.DropTable("EpisodeDirectorMapper");
            migrationBuilder.DropTable("EpisodeSubtitleStreamMapper");
            migrationBuilder.DropTable("EpisodeVideoStreamMapper");
            migrationBuilder.DropTable("MovieActorMapper");
            migrationBuilder.DropTable("MovieAudioStreamMapper");
            migrationBuilder.DropTable("MovieDirectorMapper");
            migrationBuilder.DropTable("MovieGenreMapper");
            migrationBuilder.DropTable("MovieSetMapper");
            migrationBuilder.DropTable("MovieSubtitleStreamMapper");
            migrationBuilder.DropTable("MovieVideoStreamMapper");
            migrationBuilder.DropTable("TVShowActorMapper");
            migrationBuilder.DropTable("TVShowGenreMapper");
            migrationBuilder.DropTable("Episodes");
            migrationBuilder.DropTable("AudioStreams");
            migrationBuilder.DropTable("Directors");
            migrationBuilder.DropTable("MovieGenres");
            migrationBuilder.DropTable("MovieSets");
            migrationBuilder.DropTable("SubtitleStreams");
            migrationBuilder.DropTable("Movies");
            migrationBuilder.DropTable("VideoStreams");
            migrationBuilder.DropTable("Actors");
            migrationBuilder.DropTable("TVShowGenres");
            migrationBuilder.DropTable("TVShowSeasons");
            migrationBuilder.DropTable("TVShows");
        }
    }
}
