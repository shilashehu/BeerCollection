using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerCollection.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AvgRating = table.Column<double>(type: "float", nullable: true),
                    BeerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BeerType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Oldest style of beer.", "Ale" });

            migrationBuilder.InsertData(
                table: "BeerType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "A newer style of beer.", "Lager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "BeerRating");

            migrationBuilder.DropTable(
                name: "BeerType");
        }
    }
}
