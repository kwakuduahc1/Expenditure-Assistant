using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenditureAssistant.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    ChequesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChequeNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    DateIssued = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.ChequesID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentsID);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    ExpenditureID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(maxLength: 100, nullable: false),
                    ChequesID = table.Column<int>(nullable: false),
                    PVNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentsID = table.Column<int>(nullable: false),
                    DateDone = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.ExpenditureID);
                    table.ForeignKey(
                        name: "FK_Expenditures_Cheques_ChequesID",
                        column: x => x.ChequesID,
                        principalTable: "Cheques",
                        principalColumn: "ChequesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenditures_Departments_DepartmentsID",
                        column: x => x.DepartmentsID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 1, null, "RNAC" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 2, null, "Midwifery" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 3, null, "Sports" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 4, null, "ICT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 5, null, " Administration" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 6, null, "Stores/Procurement" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 7, null, "Kitchen" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 8, null, "Estate" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 9, null, "Sports" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 10, null, "Entertainment" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 11, null, "Exams Unit" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 12, null, "Skills Unit" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ChequesID",
                table: "Expenditures",
                column: "ChequesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_DepartmentsID",
                table: "Expenditures",
                column: "DepartmentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenditures");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
