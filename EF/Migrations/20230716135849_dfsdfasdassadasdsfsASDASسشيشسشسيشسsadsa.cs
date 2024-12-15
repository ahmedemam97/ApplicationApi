using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dfsdfasdassadasdsfsASDASسشيشسشسيشسsadsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "589c94df-6fdd-4aa8-bac8-7bf1a4f9debf");

            migrationBuilder.CreateTable(
                name: "CompanyAPP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAPP", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80437c94-ac1d-40fc-ba62-bcf5bf922c2b", 0, "9bd9ad36-8246-4c53-8285-d4627f444e6d", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAPP");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "80437c94-ac1d-40fc-ba62-bcf5bf922c2b");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "589c94df-6fdd-4aa8-bac8-7bf1a4f9debf", 0, "63990939-fc44-4232-ad18-0f0744115499", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
