using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dfsdfasdassadasdsfsASDASسشيشس : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "79593cf9-c575-4a54-9bac-a6b405a3f777");

            migrationBuilder.DropColumn(
                name: "Appointments",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FromTo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "GoTo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "GoToFromAndPeriod",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "GoToFromAndWait",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Clients");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "342f7c54-2377-4ff5-8b62-10f763c4970b", 0, "0c3f6312-a5c9-44f9-9368-31618af8f1be", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "342f7c54-2377-4ff5-8b62-10f763c4970b");

            migrationBuilder.AddColumn<string>(
                name: "Appointments",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FromTo",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GoTo",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GoToFromAndPeriod",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GoToFromAndWait",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Score",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "79593cf9-c575-4a54-9bac-a6b405a3f777", 0, "738d7508-2d67-4eb8-88e6-3d5e1ffc1add", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
