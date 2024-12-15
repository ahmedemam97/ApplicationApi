using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Expened : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "f0e622b8-243b-4aa6-8924-867c8714aacd");

            migrationBuilder.CreateTable(
                name: "Expened",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expened", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4664c12c-edd7-4bdd-9db2-40b483046fff", 0, "bba88fa2-3bab-44a9-b05e-4034f34c854a", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expened");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "4664c12c-edd7-4bdd-9db2-40b483046fff");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f0e622b8-243b-4aa6-8924-867c8714aacd", 0, "bf867cbf-81b9-4d8c-98ea-d630ac62b352", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
