using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolve_Game.Migrations
{
    /// <inheritdoc />
    public partial class TimeSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBackPack",
                table: "PlayerItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBackPack",
                table: "PlayerEquips",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsBackPack",
                table: "PlayerItems");

            migrationBuilder.DropColumn(
                name: "IsBackPack",
                table: "PlayerEquips");
        }
    }
}
