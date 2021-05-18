using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_Task_5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongArtist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtist", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_SongArtist_Artist_SongId",
                        column: x => x.SongId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtist_Song_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtist_SongId",
                table: "SongArtist",
                column: "SongId");

            migrationBuilder.Sql("INSERT INTO Genre (Title) " +
                "VALUES ('Pop')," +
                "('Rock')," +
                "('Hip-Hope')," +
                "('Classical')," +
                "('Electronic')");
            migrationBuilder.Sql("INSERT INTO Artist (Name, DateOfBirth, Phone, Email, InstagramUrl) " +
                "VALUES ('Baskow', '1980-09-09', '','baskow@gmail.com', 'instabBaskow')," +
                "('Ramstain', '1960-04-12', '+380999854177', 'ramstain@gmail.com', 'instaRemstain')," +
                "('NK', '1985-04-10', '+380999854195', 'nk@gmail.com', 'instaNK')," +
                "('Pugacheva', '1940-01-01', '', '', '')," +
                "('Moby', '1965-09-11', '+38099985842', 'moby@gmail.com', 'instaMoby')");
            migrationBuilder.Sql("INSERT INTO Song (Title, Duration, ReleasedDate, GenreId) " +
                "VALUES ('TitekS1', '05:32', '2015-09-08', (SELECT GenreId From Genre WHERE Title = 'Pop'))," +
                "('TitekS2', '03:20', '2020-11-11', (SELECT GenreId From Genre WHERE Title = 'Rock'))," +
                "('TitekS3', '02:48', '2021-02-01', (SELECT GenreId From Genre WHERE Title = 'Hip-Hope'))," +
                "('TitekS4', '12:10', '1800-09-08', (SELECT GenreId From Genre WHERE Title = 'Classical'))," +
                "('TitekS5', '6:10', '2019-07-08', (SELECT GenreId From Genre WHERE Title = 'Electronic'))");
            migrationBuilder.Sql("INSERT INTO SongArtist (SongId, ArtistId) " +
                "VALUES ((SELECT SongId From Song WHERE Title = 'TitekS1'), (SELECT ArtistId From Artist WHERE Name = 'Baskow'))," +
                "((SELECT SongId From Song WHERE Title = 'TitekS2'), (SELECT ArtistId From Artist WHERE Name = 'Ramstain'))," +
                "((SELECT SongId From Song WHERE Title = 'TitekS3'), (SELECT ArtistId From Artist WHERE Name = 'NK'))," +
                "((SELECT SongId From Song WHERE Title = 'TitekS4'), (SELECT ArtistId From Artist WHERE Name = 'Baskow'))," +
                "((SELECT SongId From Song WHERE Title = 'TitekS1'), (SELECT ArtistId From Artist WHERE Name = 'Pugacheva'))," +
                "((SELECT SongId From Song WHERE Title = 'TitekS5'), (SELECT ArtistId From Artist WHERE Name = 'Moby'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongArtist");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
