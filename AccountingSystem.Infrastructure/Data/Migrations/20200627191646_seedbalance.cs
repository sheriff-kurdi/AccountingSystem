using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Infrastructure.Migrations
{
    public partial class seedbalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Balances",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Balances",
                columns: new[] { "Id", "AccountPyable", "AccountRecevable", "Building", "Capital", "Cash", "Date", "Equipments", "Goods", "Land", "Loans", "SalaryPyable" },
                values: new object[] { 1, 0.0, 0.0, 0.0, 0.0, 0.0, new DateTime(2020, 6, 27, 21, 16, 45, 652, DateTimeKind.Local).AddTicks(418), 0.0, 0.0, 0.0, 0.0, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Balances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Balances");
        }
    }
}
