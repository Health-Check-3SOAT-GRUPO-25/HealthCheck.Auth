using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCheck.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Crm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cpf", "CreatedAt", "Crm", "Email", "Name", "PasswordHash", "UpdatedAt", "UserRole" },
                values: new object[,]
                {
                    { new Guid("8d2f05bb-f651-4b26-855f-fcc445746d52"), "33333333333", new DateTime(2024, 7, 17, 21, 47, 31, 41, DateTimeKind.Utc).AddTicks(7504), null, "patient2@healthcheck.com", "Patient Two", "", null, 1 },
                    { new Guid("bf488734-a3f6-48fd-9a44-f493ee2ea028"), "22222222222", new DateTime(2024, 7, 17, 21, 47, 31, 41, DateTimeKind.Utc).AddTicks(7115), null, "patient1@healthcheck.com", "Patient One", "", null, 1 },
                    { new Guid("edd023dd-90b3-4637-95fe-581d855aeef9"), null, new DateTime(2024, 7, 17, 21, 47, 31, 41, DateTimeKind.Utc).AddTicks(5832), "000000", "doctor1@healthcheck.com", "Doctor One", "", null, 0 },
                    { new Guid("ffa0a2f0-db68-4fd7-8a39-92b40002fc34"), null, new DateTime(2024, 7, 17, 21, 47, 31, 41, DateTimeKind.Utc).AddTicks(6749), "111111", "doctor2@healthcheck.com", "Doctor Two", "", null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
