using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShortenedURLs");

            migrationBuilder.RenameColumn(
                name: "ShortURL",
                table: "ShortenedURLs",
                newName: "ShortURLId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs",
                columns: new[] { "ShortURLId", "OriginalURL" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs");

            migrationBuilder.RenameColumn(
                name: "ShortURLId",
                table: "ShortenedURLs",
                newName: "ShortURL");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ShortenedURLs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs",
                columns: new[] { "Id", "OriginalURL", "ShortURL" });
        }
    }
}
