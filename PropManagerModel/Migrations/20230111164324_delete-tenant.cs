using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManagerModel.Migrations
{
    public partial class deletetenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tenants");
        }
    }
}
