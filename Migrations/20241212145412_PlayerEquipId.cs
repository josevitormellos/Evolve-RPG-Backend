using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolve_Game.Migrations
{
    /// <inheritdoc />
    public partial class PlayerEquipId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dungeons_Chests_ChestId",
                table: "Dungeons");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMonsterEquips_Equips_IdEquip",
                table: "PlayerMonsterEquips");

            migrationBuilder.DropIndex(
                name: "IX_Dungeons_ChestId",
                table: "Dungeons");

            migrationBuilder.DropColumn(
                name: "ChestId",
                table: "Dungeons");

            migrationBuilder.RenameColumn(
                name: "IdEquip",
                table: "PlayerMonsterEquips",
                newName: "IdPlayerEquip");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMonsterEquips_IdEquip",
                table: "PlayerMonsterEquips",
                newName: "IX_PlayerMonsterEquips_IdPlayerEquip");

            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Equips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMonsterEquips_PlayerEquips_IdPlayerEquip",
                table: "PlayerMonsterEquips",
                column: "IdPlayerEquip",
                principalTable: "PlayerEquips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMonsterEquips_PlayerEquips_IdPlayerEquip",
                table: "PlayerMonsterEquips");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Equips");

            migrationBuilder.RenameColumn(
                name: "IdPlayerEquip",
                table: "PlayerMonsterEquips",
                newName: "IdEquip");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMonsterEquips_IdPlayerEquip",
                table: "PlayerMonsterEquips",
                newName: "IX_PlayerMonsterEquips_IdEquip");

            migrationBuilder.AddColumn<int>(
                name: "ChestId",
                table: "Dungeons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_ChestId",
                table: "Dungeons",
                column: "ChestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dungeons_Chests_ChestId",
                table: "Dungeons",
                column: "ChestId",
                principalTable: "Chests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMonsterEquips_Equips_IdEquip",
                table: "PlayerMonsterEquips",
                column: "IdEquip",
                principalTable: "Equips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
