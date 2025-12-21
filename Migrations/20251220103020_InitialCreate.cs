using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenGuard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptimalWateringDays = table.Column<int>(type: "int", nullable: false),
                    OptimalFertilizingDays = table.Column<int>(type: "int", nullable: false),
                    SunlightNeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinTemperature = table.Column<int>(type: "int", nullable: false),
                    MaxTemperature = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastWateredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFertilizedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPrunedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HealthScore = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlantTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_PlantTypes_PlantTypeId",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareType = table.Column<int>(type: "int", nullable: false),
                    CareDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareLogs_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlantTypes",
                columns: new[] { "Id", "Category", "Description", "MaxTemperature", "MinTemperature", "Name", "OptimalFertilizingDays", "OptimalWateringDays", "ScientificName", "SunlightNeed" },
                values: new object[,]
                {
                    { 1, "Ýç Mekan", "Zarif çiçekleriyle bilinen popüler iç mekan bitkisi", 25, 15, "Orkide", 30, 7, "Orchidaceae", "Orta" },
                    { 2, "Ýç Mekan", "Delikli yapraklarýyla dekoratif tropik bitki", 30, 18, "Monstera", 14, 7, "Monstera deliciosa", "Orta" },
                    { 3, "Ýç Mekan", "Parlak yapraklý dayanýklý iç mekan bitkisi", 30, 15, "Kauçuk", 30, 10, "Ficus elastica", "Orta" },
                    { 4, "Ýç Mekan", "Beyaz çiçekleri ve hava temizleme özelliðiyle bilinir", 25, 15, "Barýþ Zambaðý", 30, 5, "Spathiphyllum", "Az" },
                    { 5, "Ýç Mekan", "Çok az bakým gerektiren dayanýklý bitki", 30, 10, "Yýlan Bitkisi", 60, 14, "Sansevieria", "Az" },
                    { 6, "Ýç Mekan", "Þifalý özellikleriyle bilinen sukulent", 30, 10, "Aloe Vera", 60, 14, "Aloe barbadensis", "Çok" },
                    { 7, "Ýç Mekan", "Sarkan yapraklarýyla popüler asma bitki", 30, 15, "Pothos", 30, 7, "Epipremnum aureum", "Az" },
                    { 8, "Ýç Mekan", "Az su gerektiren çöl bitkisi", 35, 10, "Kaktüs", 60, 21, "Cactaceae", "Çok" },
                    { 9, "Ýç Mekan", "Çok az bakým gerektiren þanslý bitki", 30, 15, "Zamioculcas", 60, 14, "Zamioculcas zamiifolia", "Az" },
                    { 10, "Ýç Mekan", "Kalp þeklinde yapraklý popüler bitki", 30, 15, "Filodendron", 30, 7, "Philodendron", "Orta" },
                    { 11, "Dýþ Mekan", "Güzel kokulu klasik bahçe çiçeði", 30, 5, "Gül", 14, 3, "Rosa", "Çok" },
                    { 12, "Dýþ Mekan", "Hoþ kokulu mor çiçekli aromatik bitki", 35, 5, "Lavanta", 30, 7, "Lavandula", "Çok" },
                    { 13, "Dýþ Mekan", "Büyük çiçek kümeleriyle bilinen çalý", 25, 5, "Ortanca", 14, 3, "Hydrangea", "Orta" },
                    { 14, "Dýþ Mekan", "Renkli çiçekleriyle popüler balkon bitkisi", 30, 10, "Sardunya", 14, 3, "Pelargonium", "Çok" },
                    { 15, "Dýþ Mekan", "Küçük renkli çiçekleri olan kýr çiçeði", 20, 5, "Menekþe", 21, 3, "Viola", "Orta" },
                    { 16, "Sebze", "Popüler bahçe sebzesi", 35, 15, "Domates", 14, 2, "Solanum lycopersicum", "Çok" },
                    { 17, "Sebze", "Çeþitli boyut ve acýlýkta sebze", 35, 15, "Biber", 14, 2, "Capsicum", "Çok" },
                    { 18, "Sebze", "Serinletici yaz sebzesi", 35, 15, "Salatalýk", 14, 2, "Cucumis sativus", "Çok" },
                    { 19, "Sebze", "Yapraklý salata bitkisi", 25, 10, "Marul", 21, 2, "Lactuca sativa", "Orta" },
                    { 20, "Sebze", "Turuncu köklü sebze", 25, 10, "Havuç", 21, 3, "Daucus carota", "Çok" },
                    { 21, "Aromatik", "Mutfakta kullanýlan aromatik bitki", 30, 15, "Fesleðen", 21, 2, "Ocimum basilicum", "Çok" },
                    { 22, "Aromatik", "Ferahlatýcý kokulu þifalý bitki", 25, 10, "Nane", 30, 2, "Mentha", "Orta" },
                    { 23, "Aromatik", "Akdeniz mutfaðýnýn vazgeçilmezi", 30, 5, "Biberiye", 30, 7, "Rosmarinus officinalis", "Çok" },
                    { 24, "Aromatik", "Yemeklere lezzet katan aromatik bitki", 30, 5, "Kekik", 30, 7, "Thymus vulgaris", "Çok" },
                    { 25, "Aromatik", "Her yemeðe yakýþan yeþillik", 25, 10, "Maydanoz", 21, 2, "Petroselinum crispum", "Orta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareLogs_PlantId",
                table: "CareLogs",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                table: "Plants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareLogs");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
