using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class adfqweughf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "d40f6a84-0c18-4f8a-b6ec-e060e2a380f4");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "RevenueCompanyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "RevenueCompanyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "RevenueAppDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "RevenueAppDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ExpensesMonthDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "ExpensesMonthDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ExpensesDayDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "ExpensesDayDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DailyRevenue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "DailyRevenue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DailyExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "DailyExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "CompanyAPP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "CompanyAPP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByName",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PrivateTours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateTours", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "215fbfec-26c8-4807-9409-2d458f28f056", 0, "12cca291-c14d-4594-83e5-de9f7837a884", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateTours");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "215fbfec-26c8-4807-9409-2d458f28f056");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CreatedByName",
                table: "City");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d40f6a84-0c18-4f8a-b6ec-e060e2a380f4", 0, "76e6a514-108b-420e-af48-444cea2c7c7c", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
