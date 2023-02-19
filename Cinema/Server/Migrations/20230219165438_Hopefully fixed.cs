using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Server.Migrations
{
    /// <inheritdoc />
    public partial class Hopefullyfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Screenings_ScreeningID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BookingID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ScreeningID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Booked",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ScreeningID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Screenings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SeatScreenings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    SeatID = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: true),
                    ScreeningID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatScreenings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeatScreenings_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SeatScreenings_Screenings_ScreeningID",
                        column: x => x.ScreeningID,
                        principalTable: "Screenings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatScreenings_Seats_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatScreenings_BookingID",
                table: "SeatScreenings",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatScreenings_ScreeningID",
                table: "SeatScreenings",
                column: "ScreeningID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatScreenings_SeatID",
                table: "SeatScreenings",
                column: "SeatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatScreenings");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Screenings");

            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreeningID",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingID",
                table: "Seats",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ScreeningID",
                table: "Seats",
                column: "ScreeningID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Screenings_ScreeningID",
                table: "Seats",
                column: "ScreeningID",
                principalTable: "Screenings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
