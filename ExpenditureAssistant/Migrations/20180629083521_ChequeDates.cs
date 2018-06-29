using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenditureAssistant.Migrations
{
    public partial class ChequeDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PVDate",
                table: "Expenditures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ChequeDate",
                table: "Cheques",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PVDate",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "ChequeDate",
                table: "Cheques");
        }
    }
}
