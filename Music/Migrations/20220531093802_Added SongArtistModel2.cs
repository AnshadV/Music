using Microsoft.EntityFrameworkCore.Migrations;

namespace Music.Migrations
{
    public partial class AddedSongArtistModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistSongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => x.ArtistSongId);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtistSong_SongModel_SongId",
                        column: x => x.SongId,
                        principalTable: "SongModel",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_ArtistId",
                table: "ArtistSong",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongId",
                table: "ArtistSong",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");
        }
    }
}
