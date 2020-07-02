using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Infrastructure.Migrations
{
    public partial class expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeStatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    SalesRevenue = table.Column<double>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Rent = table.Column<double>(nullable: false),
                    Advertising = table.Column<double>(nullable: false),
                    Utilities = table.Column<double>(nullable: false),
                    Totall = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 6, 30, 16, 16, 46, 967, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.InsertData(
                table: "IncomeStatments",
                columns: new[] { "Id", "Advertising", "Date", "Rent", "Salary", "SalesRevenue", "Totall", "Utilities" },
                values: new object[] { 1, 0.0, new DateTime(2020, 6, 30, 16, 16, 46, 971, DateTimeKind.Local).AddTicks(5818), 0.0, 0.0, 0.0, 0.0, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeStatments");

            migrationBuilder.UpdateData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 6, 28, 0, 24, 5, 836, DateTimeKind.Local).AddTicks(5632));
        }
    }
}
