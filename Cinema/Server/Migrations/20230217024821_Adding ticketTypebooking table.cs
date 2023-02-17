using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingticketTypebookingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Seats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "BookingID",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TicketType_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketType_BookingID",
                table: "TicketType",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingID",
                table: "Seats",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
