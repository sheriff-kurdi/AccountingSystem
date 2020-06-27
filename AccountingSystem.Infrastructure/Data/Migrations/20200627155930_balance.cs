using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystem.Infrastructure.Migrations
{
    public partial class balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<double>(nullable: false),
                    AccountRecevable = table.Column<double>(nullable: false),
                    Goods = table.Column<double>(nullable: false),
                    Equipments = table.Column<double>(nullable: false),
                    Land = table.Column<double>(nullable: false),
                    Building = table.Column<double>(nullable: false),
                    AccountPyable = table.Column<double>(nullable: false),
                    SalaryPyable = table.Column<double>(nullable: false),
                    Loans = table.Column<double>(nullable: false),
                    Capital = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");
        }
    }
}
