using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_190624 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Author_AuthorId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Categories_CategoryId",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryId",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blog",
                newName: "IX_Blog_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blog",
                newName: "IX_Blog_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Author_AuthorId",
                table: "Blog",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Categories_CategoryId",
                table: "Blog",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
