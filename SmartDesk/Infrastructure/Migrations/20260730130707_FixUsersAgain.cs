using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUsersAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_Id",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_Id",
                table: "Bookings",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
