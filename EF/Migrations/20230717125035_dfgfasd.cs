using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class dfgfasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueAppDetails");

            migrationBuilder.DropTable(
                name: "RevenueCompanyDetails");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "d569488e-4bce-450f-82bd-10a4955bee9e");

            migrationBuilder.DropColumn(
                name: "TotalApp",
                table: "DailyRevenue");

            migrationBuilder.DropColumn(
                name: "TotalCompany",
                table: "DailyRevenue");

            migrationBuilder.CreateTable(
                name: "RevenueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevenueId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_RevenueDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueDetails_DailyRevenue_DailyRevenueId",
                        column: x => x.DailyRevenueId,
                        principalTable: "DailyRevenue",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "CoreIdentity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38f73e47-cce9-4f67-9b9d-2bc7943af68b", 0, "ae7cfc2f-4c9d-4ddd-a10a-37928601f0b0", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RevenueDetails_DailyRevenueId",
                table: "RevenueDetails",
                column: "DailyRevenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueDetails");

            migrationBuilder.DeleteData(
                schema: "CoreIdentity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "38f73e47-cce9-4f67-9b9d-2bc7943af68b");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalApp",
                table: "DailyRevenue",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCompany",
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
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyCount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueId = table.Column<int>(type: "int", nullable: false)
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
                    DailyRevenueId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyCount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueId = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { "d569488e-4bce-450f-82bd-10a4955bee9e", 0, "b12e2adf-76e9-4709-a409-04475032a749", "Admin@yahoo.com", true, true, null, "Admin", "ADMIN@YAHOO.COM", "ADMIN", "Admin", null, "01032882094", false, 1, "Admin", null, true, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RevenueAppDetails_DailyRevenueId",
                table: "RevenueAppDetails",
                column: "DailyRevenueId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueCompanyDetails_DailyRevenueId",
                table: "RevenueCompanyDetails",
                column: "DailyRevenueId");
        }
    }
}
