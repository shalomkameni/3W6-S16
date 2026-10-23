using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZombieParty.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Force = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Resistance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lifespan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    QtyBought = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZombieType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZombieType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zombie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZombieTypeId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Force = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zombie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zombie_ZombieType_ZombieTypeId",
                        column: x => x.ZombieTypeId,
                        principalTable: "ZombieType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "Id", "CreatedDate", "Description", "Force", "Image", "Lifespan", "Name", "Price", "Qty", "QtyBought", "Resistance", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is to cut your friendly zombies", 200m, "https://i.ibb.co/y5nCnXT/dagger-gfce31e967-1920.png", 50m, "Leopold", 421m, 21, 3, 10m, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An awesome Stainless Steel Shield", 10m, "https://publicdomainvectors.org/photos/Shield-ClassicMedieval1.png", 10m, "Master Shield", 500m, 30, 1, 800m, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ZombieType",
                columns: new[] { "Id", "Point", "TypeName" },
                values: new object[,]
                {
                    { 1, 1, "Virus" },
                    { 2, 3, "Contact" },
                    { 3, 3, "Fiction" },
                    { 4, 5, "Légendaire" }
                });

            migrationBuilder.InsertData(
                table: "Zombie",
                columns: new[] { "Id", "Force", "Image", "Name", "Point", "ShortDesc", "ZombieTypeId" },
                values: new object[,]
                {
                    { 1, 20, null, "LeChuck", 5, "description", 3 },
                    { 2, 20, null, "Lenore", 4, "description", 3 },
                    { 3, 20, null, "Draugr", 2, "description", 4 },
                    { 4, 20, null, "Ragamuffin", 5, "description", 4 },
                    { 5, 20, null, "Taxidermy", 1, "description", 4 },
                    { 6, 20, null, "chien de l'enfer", 7, "description", 3 },
                    { 7, 20, null, "Avogadro", 9, "description", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zombie_ZombieTypeId",
                table: "Zombie",
                column: "ZombieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Zombie");

            migrationBuilder.DropTable(
                name: "ZombieType");
        }
    }
}
