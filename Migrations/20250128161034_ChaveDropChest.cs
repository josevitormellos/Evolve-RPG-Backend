using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolve_Game.Migrations
{
    /// <inheritdoc />
    public partial class ChaveDropChest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chests_Drops_DropId",
                table: "Chests");

            migrationBuilder.DropIndex(
                name: "IX_Chests_DropId",
                table: "Chests");

            migrationBuilder.DropColumn(
                name: "DropId",
                table: "Chests");

            migrationBuilder.CreateIndex(
                name: "IX_Chests_IdDrop",
                table: "Chests",
                column: "IdDrop");

            migrationBuilder.AddForeignKey(
                name: "FK_Chests_Drops_IdDrop",
                table: "Chests",
                column: "IdDrop",
                principalTable: "Drops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chests_Drops_IdDrop",
                table: "Chests");

            migrationBuilder.DropIndex(
                name: "IX_Chests_IdDrop",
                table: "Chests");

            migrationBuilder.AddColumn<int>(
                name: "DropId",
                table: "Chests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chests_DropId",
                table: "Chests",
                column: "DropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chests_Drops_DropId",
                table: "Chests",
                column: "DropId",
                principalTable: "Drops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
