using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCReportingSystem.BranchOffice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    AutomobileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    BranchOfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.AutomobileId);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    BranchOfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchOfficeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchOfficeState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchOfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchOfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Automobiles",
                columns: new[] { "AutomobileId", "BranchOfficeId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("65a1e10e-68ad-4ddc-b92c-32d36cf45cee"), -1, "Tesla", "Model S", 2021 },
                    { new Guid("1f8267e5-78f1-49ed-8476-823d4d439352"), -2, "Toyota", "RAV4", 2021 },
                    { new Guid("ccd557c5-877f-482f-bca1-722d5198b0a9"), -3, "Hyundai", "KONA", 2021 }
                });

            migrationBuilder.InsertData(
                table: "BranchOffices",
                columns: new[] { "BranchOfficeId", "BranchOfficeCountry", "BranchOfficeState" },
                values: new object[,]
                {
                    { -1, "US", "California" },
                    { -2, "US", "New York" },
                    { -3, "US", "Massachusetts" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BranchOfficeId", "FirstName", "LastName", "Username" },
                values: new object[,]
                {
                    { new Guid("fb0f1585-cb42-4f01-a25d-6e441b414f72"), -1, "Dio", "Brando", "diobrando1" },
                    { new Guid("189a302d-1aa7-4110-a43d-833183446a4b"), -2, "Jolyne", "Cujoh", "jolynecujoh" },
                    { new Guid("f3022c0b-d875-45a1-9c36-bec333877595"), -3, "Gyro", "Zepelli", "gzepelli" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
