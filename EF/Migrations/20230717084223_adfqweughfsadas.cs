using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class adfqweughfsadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "215fbfec-26c8-4807-9409-2d458f28f056");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "RevenueCompanyDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "RevenueCompanyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "RevenueCompanyDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "RevenueCompanyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "RevenueAppDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "RevenueAppDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "RevenueAppDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "RevenueAppDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "PrivateTours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "PrivateTours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "PrivateTours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "PrivateTours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Maintenances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Maintenances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ExpensesMonthDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "ExpensesMonthDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "ExpensesMonthDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "ExpensesMonthDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ExpensesDayDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "ExpensesDayDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "ExpensesDayDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "ExpensesDayDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Driver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "Driver",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "DailyRevenue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "DailyRevenue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "DailyRevenue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "DailyRevenue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "DailyExpenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "DailyExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "DailyExpenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "DailyExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "CompanyAPP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "CompanyAPP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "CompanyAPP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "CompanyAPP",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyById",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyByName",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74418115-5763-4d8b-a2b0-98202624ee2f", 0, "2effad86-dab9-4b74-b5ff-87d00aed83d2", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "74418115-5763-4d8b-a2b0-98202624ee2f");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "RevenueCompanyDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "RevenueAppDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PrivateTours");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "PrivateTours");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "PrivateTours");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "PrivateTours");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "ExpensesMonthDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "ExpensesDayDetails");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "CompanyAPP");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ModifyByName",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "City");

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "215fbfec-26c8-4807-9409-2d458f28f056", 0, "12cca291-c14d-4594-83e5-de9f7837a884", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
