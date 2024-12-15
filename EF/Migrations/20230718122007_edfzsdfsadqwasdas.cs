using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class edfzsdfsadqwasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e8774504-bdab-4237-afe5-f689f8a45001");

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "RevenueDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "RevenueDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fdc7768d-a7e2-4d94-86c5-74238ea2729f", 0, "bec67539-9523-4708-8d4f-1e3dda0bcf2d", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "fdc7768d-a7e2-4d94-86c5-74238ea2729f");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "RevenueDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "RevenueDetails");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e8774504-bdab-4237-afe5-f689f8a45001", 0, "13a11fa9-8422-41bf-bc1d-515e0228af02", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
