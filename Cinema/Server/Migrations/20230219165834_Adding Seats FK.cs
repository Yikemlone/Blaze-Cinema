using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeatsFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomID",
                table: "Seats",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Rooms_RoomID",
                table: "Seats",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Rooms_RoomID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_RoomID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Seats");
        }
    }
}
