using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixedMoviename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MmovieID",
                table: "Screenings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MmovieID",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
