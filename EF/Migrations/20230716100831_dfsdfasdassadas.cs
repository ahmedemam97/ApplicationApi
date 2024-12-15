using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dfsdfasdassadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "cc8a5e0b-a458-4c3d-a16f-188ac3f9296b");

            migrationBuilder.DropColumn(
                name: "Card",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CostCarem",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CostDede",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CostInDrive",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CostLimousine",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "CostUber",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "DriverCash",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "Garage",
                table: "DailyExpenses");

            migrationBuilder.DropColumn(
                name: "Gas",
                table: "DailyExpenses");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "DailyExpenses",
                newName: "TotalExpensesMonth");

            migrationBuilder.RenameColumn(
                name: "Petrol",
                table: "DailyExpenses",
                newName: "TotalExpensesDay");

            migrationBuilder.CreateTable(
                name: "ExpensesDayDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyExpensesId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesDayDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesDayDetails_DailyExpenses_DailyExpensesId",
                        column: x => x.DailyExpensesId,
                        principalTable: "DailyExpenses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpensesMonthDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyExpensesId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesMonthDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesMonthDetails_DailyExpenses_DailyExpensesId",
                        column: x => x.DailyExpensesId,
                        principalTable: "DailyExpenses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "695a5e62-1ccf-48cf-bd5e-e314ff45bf13", 0, "741bf5d6-bbcc-4416-b296-a9cd11d097ee", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesDayDetails_DailyExpensesId",
                table: "ExpensesDayDetails",
                column: "DailyExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesMonthDetails_DailyExpensesId",
                table: "ExpensesMonthDetails",
                column: "DailyExpensesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensesDayDetails");

            migrationBuilder.DropTable(
                name: "ExpensesMonthDetails");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "695a5e62-1ccf-48cf-bd5e-e314ff45bf13");

            migrationBuilder.RenameColumn(
                name: "TotalExpensesMonth",
                table: "DailyExpenses",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "TotalExpensesDay",
                table: "DailyExpenses",
                newName: "Petrol");

            migrationBuilder.AddColumn<decimal>(
                name: "Card",
                table: "DailyExpenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "CostCarem",
                table: "DailyExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CostDede",
                table: "DailyExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CostInDrive",
                table: "DailyExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CostLimousine",
                table: "DailyExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CostUber",
                table: "DailyExpenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "DriverCash",
                table: "DailyExpenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Garage",
                table: "DailyExpenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Gas",
                table: "DailyExpenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cc8a5e0b-a458-4c3d-a16f-188ac3f9296b", 0, "f0a243b0-8905-4922-bb76-3d2cdaa1f434", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });
        }
    }
}
