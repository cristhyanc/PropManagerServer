using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManagerModel.Migrations
{
    public partial class expenseextrafields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DueDate",
                table: "Expenses",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Expenses");
        }
    }
}
