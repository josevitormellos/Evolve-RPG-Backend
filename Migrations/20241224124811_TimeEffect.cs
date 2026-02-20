using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolve_Game.Migrations
{
    /// <inheritdoc />
    public partial class TimeEffect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeEffectContinue",
                table: "Effects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeEffectContinue",
                table: "Effects");
        }
    }
}
