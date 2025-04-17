using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carbook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_06042025_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "RentACars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PickUpLocationId",
                table: "RentACars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
