using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dafaassadaspjklKOJasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7fcc474c-9c09-45f7-91c3-fa35e1973cac");

            migrationBuilder.DropColumn(
                name: "DocDate",
                table: "City");

            migrationBuilder.AddColumn<decimal>(
                name: "Hour",
                table: "City",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d40f6a84-0c18-4f8a-b6ec-e060e2a380f4", 0, "76e6a514-108b-420e-af48-444cea2c7c7c", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "d40f6a84-0c18-4f8a-b6ec-e060e2a380f4");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "City");

            migrationBuilder.AddColumn<DateTime>(
                name: "DocDate",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7fcc474c-9c09-45f7-91c3-fa35e1973cac", 0, "c978c866-9efa-41a0-b545-fdcf34344148", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
