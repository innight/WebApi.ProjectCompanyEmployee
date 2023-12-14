using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.ProjectCompanyEmployee.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HiredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Founded", "Industry", "LogoUrl", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "This is a dummy company.", new DateTime(2013, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(3917), "Tech", "https://www.dummycompany1.com/logo.png", "Dummy Company 1", "https://www.dummycompany1.com" },
                    { 2, "This is another dummy company.", new DateTime(2018, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(3996), "Finance", "https://www.dummycompany2.com/logo.png", "Dummy Company 2", "https://www.dummycompany2.com" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "CompanyId", "Department", "Email", "FirstName", "HiredOn", "LastName", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Engineering", "john.doe@dummycompany.com", "John", new DateTime(2021, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(4202), "Doe", "Software Engineer" },
                    { 2, 1, "Engineering", "john.doe@dummycompany.com", "John 2", new DateTime(2022, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(4210), "Doe 2", "Software Engineer" },
                    { 3, 2, "Engineering", "john.doe@dummycompany.com", "John 3", new DateTime(2021, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(4214), "Doe 3", "Software Engineer" },
                    { 4, 2, "Engineering", "john.doe@dummycompany.com", "John 4", new DateTime(2022, 12, 11, 8, 26, 7, 448, DateTimeKind.Local).AddTicks(4218), "Doe 4", "Software Engineer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
