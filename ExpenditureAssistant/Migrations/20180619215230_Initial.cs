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
                    Status = table.Column<bool>(nullable: false),
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
                name: "ExpenditureItems",
                columns: table => new
                {
                    ExpenditureItemsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureItems", x => x.ExpenditureItemsID);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    ExpenditureID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(maxLength: 100, nullable: false),
                    ChequesID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PVNumber = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentsID = table.Column<int>(nullable: false),
                    ExpenditureItemsID = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Expenditures_ExpenditureItems_ExpenditureItemsID",
                        column: x => x.ExpenditureItemsID,
                        principalTable: "ExpenditureItems",
                        principalColumn: "ExpenditureItemsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 1, null, "RNAC" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 13, null, "Nutrition" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 11, null, "Exams Unit" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 10, null, "Entertainment" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 9, null, "SRC" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 8, null, "Estate" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 12, null, "Psycho-motor Unit" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 6, null, "Stores/Procurement" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 5, null, "Administration" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 4, null, "ICT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 3, null, "Sports" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 2, null, "Midwifery" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentsID", "Concurrency", "Department" },
                values: new object[] { 7, null, "Kitchen" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 36, 2210407, "Rental of Other Transport" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 35, 2210708, "Refreshments" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 34, 2210707, "Recruitment Expenses" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 53, 2310019, "Purchase of Plant & Equipment" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 32, 2210101, "Printed Material & Stationery" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 33, 2821002, "Professional fees" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 6, 2112238, "Overtime Allowance" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 5, 2112247, "Overtime" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 37, 2210406, "Rental of Vehicles" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 52, 2310018, "Purchase of Motor Bike, bicycles etc" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 38, 2210603, "Repairs of Office Buildings" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 45, 2731102, "Staff Welfare Expenses" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 40, 2210402, "Residential Accommodations" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 41, 2210601, "Roads, Driveways & Grounds" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 42, 2210505, "Running Cost - Official Vehicles" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 43, 2210709, "Seminars/Conferences/Workshops/Meetings Expenses" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 44, 2210710, "Staff Development" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 31, 2210509, "Other Travel & Transportation" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 46, 2210117, "Teaching & Learning Materials" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 47, 2210203, "Telecommunications" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 48, 2210115, "Textbooks & Library Books" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 49, 2210701, "Training Materials" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 7, 2112242, "Travel Allowance" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 39, 2210602, "Repairs of Residential Buildings" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 30, 2210111, "Other Office Materials and Consumables" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 25, 2210605, "Maintenance of Machinery & Plant" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 26, 2210805, "Materials and Consumables (Reimbursable)" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 2, 2112228, "Academic Board Allowances" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 8, 2211101, "Bank Charges" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 9, 2210116, "Chemicals & Consumables" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 10, 2210301, "Cleaning Materials" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 11, 2210121, "Clothing and Uniform" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 12, 2210108, "Construction Material" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 13, 2210302, "Contract Cleaning Service Charges" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 14, 2210107, "Electrical Accessories" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 15, 2210201, "Electricity charges" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 16, 2210703, "Examination Fees and Expenses" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 17, 2210113, "Feeding Cost" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 18, 2210503, "Fuel & Lubricants - Official Vehicles" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 3, 2112234, "Fuel Allowance" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 19, 2210705, "Hotel Accommodation" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 20, 2210404, "Hotel Accommodations" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 21, 2821001, "Insurance and compensation" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 22, 2210511, "Local travel cost" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 23, 2210502, "Maintenance & Repairs - Official Vehicles" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 24, 2210604, "Maintenance of Furniture & Fixtures" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 50, 2210112, "Uniform and Protective Clothing" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 27, 2210104, "Medical Supplies" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 4, 2111102, "Monthly paid & casual labour" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 28, 2210510, "Night allowances" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 29, 2210102, "Office Facilities, Supplies & Accessories" });

            migrationBuilder.InsertData(
                table: "ExpenditureItems",
                columns: new[] { "ExpenditureItemsID", "AccountNumber", "Description" },
                values: new object[] { 51, 2210202, "Water" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ChequesID",
                table: "Expenditures",
                column: "ChequesID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_DepartmentsID",
                table: "Expenditures",
                column: "DepartmentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ExpenditureItemsID",
                table: "Expenditures",
                column: "ExpenditureItemsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenditures");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "ExpenditureItems");
        }
    }
}
