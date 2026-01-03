using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenGuard.Migrations
{
    /// <inheritdoc />
    public partial class AddOptimalPruningDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptimalPruningDays",
                table: "PlantTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "OptimalPruningDays",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "OptimalPruningDays",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "OptimalPruningDays",
                value: 60);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "OptimalPruningDays",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "OptimalPruningDays",
                value: 90);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "OptimalPruningDays",
                value: 60);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "OptimalPruningDays",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "OptimalPruningDays",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "OptimalPruningDays",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "OptimalPruningDays",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "OptimalPruningDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "OptimalPruningDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "OptimalPruningDays",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "OptimalPruningDays",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlantTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "OptimalPruningDays",
                value: 14);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptimalPruningDays",
                table: "PlantTypes");
        }
    }
}
