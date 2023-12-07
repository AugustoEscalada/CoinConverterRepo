using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinConverter.Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Currency",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_UserId",
                table: "Currency",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Users_UserId",
                table: "Currency",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Users_UserId",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_UserId",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Currency");
        }
    }
}
