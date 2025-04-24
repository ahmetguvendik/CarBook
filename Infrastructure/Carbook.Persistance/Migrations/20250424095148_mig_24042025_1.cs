using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carbook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_24042025_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Statues",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statues",
                table: "Reservations");
        }
    }
}
