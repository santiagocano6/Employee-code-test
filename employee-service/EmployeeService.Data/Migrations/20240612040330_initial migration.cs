using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeService.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmploymentTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Permanent" },
                    { 2, "Freelance" },
                    { 3, "Intern" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedOn", "Email", "EmploymentTypeId", "FirstName", "LastName", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2011, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "holmes@detectives.org", 1, "Sherlock", "Holmes", new DateTime(2011, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2013, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "marple@detectives.org", 2, "Jane", "Marple", new DateTime(2013, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2012, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "poirot@detectives.org", 1, "Hercule", "Poirot", new DateTime(2012, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "drew@detectives.org", 3, "Nancy", "Drew", new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "fletcher@detectives.org", 2, "Jessica", "Fletcher", new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2016, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "columbo@detectives.org", 1, "Frank", "Columbo", new DateTime(2016, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmploymentTypeId",
                table: "Employees",
                column: "EmploymentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");
        }
    }
}
