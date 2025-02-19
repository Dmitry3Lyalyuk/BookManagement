using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "viewCount",
                table: "Books",
                newName: "ViewCount");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "publicationYear",
                table: "Books",
                newName: "PublicationYear");

            migrationBuilder.RenameColumn(
                name: "authorName",
                table: "Books",
                newName: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewCount",
                table: "Books",
                newName: "viewCount");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "PublicationYear",
                table: "Books",
                newName: "publicationYear");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Books",
                newName: "authorName");
        }
    }
}
