using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManagerModel.Migrations
{
    public partial class expenseRecurrance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDeductable",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "Expenses",
                newName: "ExpenseRecurrence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseRecurrence",
                table: "Expenses",
                newName: "Frequency");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDeductable",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
