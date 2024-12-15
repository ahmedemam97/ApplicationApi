using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class edfzsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "5c34bb1b-d39a-4689-991e-c2a737399f5c");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "96dd4ccc-25b5-4ea6-a464-c3ae0c36c4c7", 0, "05c769a1-beb7-4821-ba23-d6d7ba79ab43", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "96dd4ccc-25b5-4ea6-a464-c3ae0c36c4c7");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Bookings");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5c34bb1b-d39a-4689-991e-c2a737399f5c", 0, "84156230-1bc2-4f53-b4bb-0a4bce36c978", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
