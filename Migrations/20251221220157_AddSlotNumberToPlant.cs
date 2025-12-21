using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGuard.Migrations
{
    /// <inheritdoc />
    public partial class AddSlotNumberToPlant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlotNumber",
                table: "Plants",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotNumber",
                table: "Plants");
        }
    }
}
