using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManagerModel.Migrations
{
    public partial class directdebitexpensive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDirectDebit",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDirectDebit",
                table: "Expenses");
        }
    }
}
