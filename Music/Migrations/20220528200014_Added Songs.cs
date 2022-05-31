using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Music.Migrations
{
    public partial class AddedSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongModel",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    CoverImage = table.Column<byte[]>(type: "varbinary(MAX)", nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongModel", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_SongModel_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongModel_ArtistId",
                table: "SongModel",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongModel");
        }
    }
}
