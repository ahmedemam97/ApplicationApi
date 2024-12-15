using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dafaassadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyRevenueDetails");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "bbca00be-4e4a-473a-85dd-433e16186b82");

            migrationBuilder.RenameColumn(
                name: "TotalIncomeVisa",
                table: "DailyRevenue",
                newName: "TotalCompany");

            migrationBuilder.RenameColumn(
                name: "TotalIncomeCash",
                table: "DailyRevenue",
                newName: "TotalApp");

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "DailyRevenue",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "RevenueAppDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueAppDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueAppDetails_DailyRevenue_DailyRevenueId",
                        column: x => x.DailyRevenueId,
                        principalTable: "DailyRevenue",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RevenueCompanyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueCompanyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueCompanyDetails_DailyRevenue_DailyRevenueId",
                        column: x => x.DailyRevenueId,
                        principalTable: "DailyRevenue",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4541cc72-682f-4d86-9e33-6f0725f77ae3", 0, "0affe8e1-ec93-4c86-8aa3-6cd181ad9fd0", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RevenueAppDetails_DailyRevenueId",
                table: "RevenueAppDetails",
                column: "DailyRevenueId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueCompanyDetails_DailyRevenueId",
                table: "RevenueCompanyDetails",
                column: "DailyRevenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueAppDetails");

            migrationBuilder.DropTable(
                name: "RevenueCompanyDetails");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "4541cc72-682f-4d86-9e33-6f0725f77ae3");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "DailyRevenue");

            migrationBuilder.RenameColumn(
                name: "TotalCompany",
                table: "DailyRevenue",
                newName: "TotalIncomeVisa");

            migrationBuilder.RenameColumn(
                name: "TotalApp",
                table: "DailyRevenue",
                newName: "TotalIncomeCash");

            migrationBuilder.CreateTable(
                name: "DailyRevenueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRevenueDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyRevenueDetails_DailyRevenue_DailyRevenueId",
                        column: x => x.DailyRevenueId,
                        principalTable: "DailyRevenue",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bbca00be-4e4a-473a-85dd-433e16186b82", 0, "e76f8275-2705-4b90-b059-3c04118e3b9d", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyRevenueDetails_DailyRevenueId",
                table: "DailyRevenueDetails",
                column: "DailyRevenueId");
        }
    }
}
