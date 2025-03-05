using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs");

            migrationBuilder.AddColumn<string>(
                name: "Base64QRCode",
                table: "ShortenedURLs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs",
                column: "ShortURLId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs");

            migrationBuilder.DropColumn(
                name: "Base64QRCode",
                table: "ShortenedURLs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortenedURLs",
                table: "ShortenedURLs",
                columns: new[] { "ShortURLId", "OriginalURL" });
        }
    }
}
