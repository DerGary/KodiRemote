using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KodiRemote.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addons",
                columns: table => new
                {
                    AddonId = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Broken = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Disclaimer = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Fanart = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddonTableEntry", x => x.AddonId);
                });
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
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    AlbumLabel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayArtist = table.Column<string>(nullable: true),
                    Fanart = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    PlayCount = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumTableEntry", x => x.AlbumId);
                });
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: true),
                    Born = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Died = table.Column<string>(nullable: true),
                    Fanart = table.Column<string>(nullable: true),
                    Formed = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTableEntry", x => x.ArtistId);
                });
            migrationBuilder.CreateTable(
                name: "MusicGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenreTableEntry", x => x.GenreId);
                    table.UniqueConstraint("AK_string_Genre", x => x.Genre);
                });
            migrationBuilder.CreateTable(
                name: "MusicPlaylists",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylistTableEntry", x => x.PlaylistId);
                });
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Album = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DisplayArtist = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Fanart = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    PlayCount = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Track = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongTableEntry", x => x.SongId);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoArtists",
                columns: table => new
                {
                    MusicVideoArtistId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoArtistTableEntry", x => x.MusicVideoArtistId);
                    table.UniqueConstraint("AK_string_Name", x => x.Name);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoGenres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoGenreTableEntry", x => x.GenreId);
                    table.UniqueConstraint("AK_string_Genre", x => x.Genre);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideos",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    Album = table.Column<string>(nullable: true),
                    DateAdded = table.Column<string>(nullable: true),
                    Fanart = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    PlayCount = table.Column<int>(nullable: false),
                    Plot = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: true),
                    Track = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoTableEntry", x => x.MusicVideoId);
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
                name: "MovieMovieSetMapper",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    MovieSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieSetMapper", x => new { x.MovieId, x.MovieSetId });
                    table.ForeignKey(
                        name: "FK_MovieMovieSetMapper_MovieTableEntry_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieSetMapper_MovieSetTableEntry_MovieSetId",
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
                name: "AlbumArtistMapper",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtistMapper", x => new { x.AlbumId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_AlbumArtistMapper_AlbumTableEntry_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtistMapper_ArtistTableEntry_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AlbumGenreMapper",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenreMapper", x => new { x.AlbumId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_AlbumGenreMapper_AlbumTableEntry_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumGenreMapper_MusicGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "MusicGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicPlaylistSongMapper",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylistSongMapper", x => new { x.SongId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_MusicPlaylistSongMapper_SongTableEntry_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistSongMapper_MusicPlaylistTableEntry_SongId",
                        column: x => x.SongId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SongAlbumMapper",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAlbumMapper", x => new { x.SongId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_SongAlbumMapper_SongTableEntry_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongAlbumMapper_AlbumTableEntry_SongId",
                        column: x => x.SongId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SongArtistMapper",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtistMapper", x => new { x.SongId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_SongArtistMapper_ArtistTableEntry_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtistMapper_SongTableEntry_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SongGenreMapper",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenreMapper", x => new { x.SongId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_SongGenreMapper_MusicGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "MusicGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongGenreMapper_SongTableEntry_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoArtistMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    MusicVideoArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoArtistMapper", x => new { x.MusicVideoId, x.MusicVideoArtistId });
                    table.ForeignKey(
                        name: "FK_MusicVideoArtistMapper_MusicVideoArtistTableEntry_MusicVideoArtistId",
                        column: x => x.MusicVideoArtistId,
                        principalTable: "MusicVideoArtists",
                        principalColumn: "MusicVideoArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoArtistMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoAudioStreamMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    AudioStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoAudioStreamMapper", x => new { x.MusicVideoId, x.AudioStreamId });
                    table.ForeignKey(
                        name: "FK_MusicVideoAudioStreamMapper_AudioStreamTableEntry_AudioStreamId",
                        column: x => x.AudioStreamId,
                        principalTable: "AudioStreams",
                        principalColumn: "AudioStreamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoAudioStreamMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoDirectorMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoDirectorMapper", x => new { x.MusicVideoId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MusicVideoDirectorMapper_DirectorTableEntry_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoDirectorMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoGenreMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoGenreMapper", x => new { x.MusicVideoId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MusicVideoGenreMapper_MusicVideoGenreTableEntry_GenreId",
                        column: x => x.GenreId,
                        principalTable: "MusicVideoGenres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoGenreMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoSubtitleStreamMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    SubtitleStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoSubtitleStreamMapper", x => new { x.MusicVideoId, x.SubtitleStreamId });
                    table.ForeignKey(
                        name: "FK_MusicVideoSubtitleStreamMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoSubtitleStreamMapper_SubtitleStreamTableEntry_SubtitleStreamId",
                        column: x => x.SubtitleStreamId,
                        principalTable: "SubtitleStreams",
                        principalColumn: "SubtitleStreamId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "MusicVideoVideoStreamMapper",
                columns: table => new
                {
                    MusicVideoId = table.Column<int>(nullable: false),
                    VideoStreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideoVideoStreamMapper", x => new { x.MusicVideoId, x.VideoStreamId });
                    table.ForeignKey(
                        name: "FK_MusicVideoVideoStreamMapper_MusicVideoTableEntry_MusicVideoId",
                        column: x => x.MusicVideoId,
                        principalTable: "MusicVideos",
                        principalColumn: "MusicVideoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideoVideoStreamMapper_VideoStreamTableEntry_VideoStreamId",
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
            migrationBuilder.DropTable("Addons");
            migrationBuilder.DropTable("EpisodeActorMapper");
            migrationBuilder.DropTable("EpisodeAudioStreamMapper");
            migrationBuilder.DropTable("EpisodeDirectorMapper");
            migrationBuilder.DropTable("EpisodeSubtitleStreamMapper");
            migrationBuilder.DropTable("EpisodeVideoStreamMapper");
            migrationBuilder.DropTable("MovieActorMapper");
            migrationBuilder.DropTable("MovieAudioStreamMapper");
            migrationBuilder.DropTable("MovieDirectorMapper");
            migrationBuilder.DropTable("MovieGenreMapper");
            migrationBuilder.DropTable("MovieMovieSetMapper");
            migrationBuilder.DropTable("MovieSubtitleStreamMapper");
            migrationBuilder.DropTable("MovieVideoStreamMapper");
            migrationBuilder.DropTable("AlbumArtistMapper");
            migrationBuilder.DropTable("AlbumGenreMapper");
            migrationBuilder.DropTable("MusicPlaylistSongMapper");
            migrationBuilder.DropTable("SongAlbumMapper");
            migrationBuilder.DropTable("SongArtistMapper");
            migrationBuilder.DropTable("SongGenreMapper");
            migrationBuilder.DropTable("MusicVideoArtistMapper");
            migrationBuilder.DropTable("MusicVideoAudioStreamMapper");
            migrationBuilder.DropTable("MusicVideoDirectorMapper");
            migrationBuilder.DropTable("MusicVideoGenreMapper");
            migrationBuilder.DropTable("MusicVideoSubtitleStreamMapper");
            migrationBuilder.DropTable("MusicVideoVideoStreamMapper");
            migrationBuilder.DropTable("TVShowActorMapper");
            migrationBuilder.DropTable("TVShowGenreMapper");
            migrationBuilder.DropTable("Episodes");
            migrationBuilder.DropTable("MovieGenres");
            migrationBuilder.DropTable("MovieSets");
            migrationBuilder.DropTable("Movies");
            migrationBuilder.DropTable("MusicPlaylists");
            migrationBuilder.DropTable("Albums");
            migrationBuilder.DropTable("Artists");
            migrationBuilder.DropTable("MusicGenres");
            migrationBuilder.DropTable("Songs");
            migrationBuilder.DropTable("MusicVideoArtists");
            migrationBuilder.DropTable("AudioStreams");
            migrationBuilder.DropTable("Directors");
            migrationBuilder.DropTable("MusicVideoGenres");
            migrationBuilder.DropTable("SubtitleStreams");
            migrationBuilder.DropTable("MusicVideos");
            migrationBuilder.DropTable("VideoStreams");
            migrationBuilder.DropTable("Actors");
            migrationBuilder.DropTable("TVShowGenres");
            migrationBuilder.DropTable("TVShowSeasons");
            migrationBuilder.DropTable("TVShows");
        }
    }
}
