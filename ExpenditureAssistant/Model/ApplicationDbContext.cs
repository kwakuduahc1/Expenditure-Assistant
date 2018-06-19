using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=accountant.db;", x =>
            {
                x.SuppressForeignKeyEnforcement(false);
                x.UseRelationalNulls(true);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(x => x.HasData(
                new Departments { Department = "RNAC", DepartmentsID = 1 },
                new Departments { Department = "Midwifery", DepartmentsID = 2 },
                new Departments { Department = "Sports", DepartmentsID = 3 },
                new Departments { Department = "ICT", DepartmentsID = 4 },
                new Departments { Department = "Administration", DepartmentsID = 5 },
                new Departments { Department = "Stores/Procurement", DepartmentsID = 6 },
                new Departments { Department = "Kitchen", DepartmentsID = 7 },
                new Departments { Department = "Estate", DepartmentsID = 8 },
                new Departments { Department = "SRC", DepartmentsID = 9 },
                new Departments { Department = "Entertainment", DepartmentsID = 10 },
                new Departments { Department = "Exams Unit", DepartmentsID = 11 },
                new Departments { Department = "Psycho-motor Unit", DepartmentsID = 12 },
                new Departments { Department = "Nutrition", DepartmentsID = 13 }
                ));

            modelBuilder.Entity<ExpenditureItems>(x => x.HasData(
                 new ExpenditureItems { ExpenditureItemsID = 2, AccountNumber = 2112228, Description = "Academic Board Allowances" },
                new ExpenditureItems { ExpenditureItemsID = 8, AccountNumber = 2211101, Description = "Bank Charges" },
                new ExpenditureItems { ExpenditureItemsID = 9, AccountNumber = 2210116, Description = "Chemicals & Consumables" },
                new ExpenditureItems { ExpenditureItemsID = 10, AccountNumber = 2210301, Description = "Cleaning Materials" },
                new ExpenditureItems { ExpenditureItemsID = 11, AccountNumber = 2210121, Description = "Clothing and Uniform" },
                new ExpenditureItems { ExpenditureItemsID = 12, AccountNumber = 2210108, Description = "Construction Material" },
                new ExpenditureItems { ExpenditureItemsID = 13, AccountNumber = 2210302, Description = "Contract Cleaning Service Charges" },
                new ExpenditureItems { ExpenditureItemsID = 14, AccountNumber = 2210107, Description = "Electrical Accessories" },
                new ExpenditureItems { ExpenditureItemsID = 15, AccountNumber = 2210201, Description = "Electricity charges" },
                new ExpenditureItems { ExpenditureItemsID = 16, AccountNumber = 2210703, Description = "Examination Fees and Expenses" },
                new ExpenditureItems { ExpenditureItemsID = 17, AccountNumber = 2210113, Description = "Feeding Cost" },
                new ExpenditureItems { ExpenditureItemsID = 18, AccountNumber = 2210503, Description = "Fuel & Lubricants - Official Vehicles" },
                new ExpenditureItems { ExpenditureItemsID = 3, AccountNumber = 2112234, Description = "Fuel Allowance" },
                new ExpenditureItems { ExpenditureItemsID = 19, AccountNumber = 2210705, Description = "Hotel Accommodation" },
                new ExpenditureItems { ExpenditureItemsID = 20, AccountNumber = 2210404, Description = "Hotel Accommodations" },
                new ExpenditureItems { ExpenditureItemsID = 21, AccountNumber = 2821001, Description = "Insurance and compensation" },
                new ExpenditureItems { ExpenditureItemsID = 22, AccountNumber = 2210511, Description = "Local travel cost" },
                new ExpenditureItems { ExpenditureItemsID = 23, AccountNumber = 2210502, Description = "Maintenance & Repairs - Official Vehicles" },
                new ExpenditureItems { ExpenditureItemsID = 24, AccountNumber = 2210604, Description = "Maintenance of Furniture & Fixtures" },
                new ExpenditureItems { ExpenditureItemsID = 25, AccountNumber = 2210605, Description = "Maintenance of Machinery & Plant" },
                new ExpenditureItems { ExpenditureItemsID = 27, AccountNumber = 2210104, Description = "Medical Supplies" },
                new ExpenditureItems { ExpenditureItemsID = 4, AccountNumber = 2111102, Description = "Monthly paid & casual labour" },
                new ExpenditureItems { ExpenditureItemsID = 28, AccountNumber = 2210510, Description = "Night allowances" },
                new ExpenditureItems { ExpenditureItemsID = 26, AccountNumber = 2210805, Description = "Materials and Consumables (Reimbursable)" },
                new ExpenditureItems { ExpenditureItemsID = 29, AccountNumber = 2210102, Description = "Office Facilities, Supplies & Accessories" },
                new ExpenditureItems { ExpenditureItemsID = 30, AccountNumber = 2210111, Description = "Other Office Materials and Consumables" },
                new ExpenditureItems { ExpenditureItemsID = 31, AccountNumber = 2210509, Description = "Other Travel & Transportation" },
                new ExpenditureItems { ExpenditureItemsID = 5, AccountNumber = 2112247, Description = "Overtime" },
                new ExpenditureItems { ExpenditureItemsID = 6, AccountNumber = 2112238, Description = "Overtime Allowance" },
                new ExpenditureItems { ExpenditureItemsID = 32, AccountNumber = 2210101, Description = "Printed Material & Stationery" },
                new ExpenditureItems { ExpenditureItemsID = 33, AccountNumber = 2821002, Description = "Professional fees" },
                new ExpenditureItems { ExpenditureItemsID = 52, AccountNumber = 2310018, Description = "Purchase of Motor Bike, bicycles etc" },
                new ExpenditureItems { ExpenditureItemsID = 53, AccountNumber = 2310019, Description = "Purchase of Plant & Equipment" },
                new ExpenditureItems { ExpenditureItemsID = 34, AccountNumber = 2210707, Description = "Recruitment Expenses" },
                new ExpenditureItems { ExpenditureItemsID = 35, AccountNumber = 2210708, Description = "Refreshments" },
                new ExpenditureItems { ExpenditureItemsID = 36, AccountNumber = 2210407, Description = "Rental of Other Transport" },
                new ExpenditureItems { ExpenditureItemsID = 37, AccountNumber = 2210406, Description = "Rental of Vehicles" },
                new ExpenditureItems { ExpenditureItemsID = 38, AccountNumber = 2210603, Description = "Repairs of Office Buildings" },
                new ExpenditureItems { ExpenditureItemsID = 39, AccountNumber = 2210602, Description = "Repairs of Residential Buildings" },
                new ExpenditureItems { ExpenditureItemsID = 40, AccountNumber = 2210402, Description = "Residential Accommodations" },
                new ExpenditureItems { ExpenditureItemsID = 41, AccountNumber = 2210601, Description = "Roads, Driveways & Grounds" },
                new ExpenditureItems { ExpenditureItemsID = 42, AccountNumber = 2210505, Description = "Running Cost - Official Vehicles" },
                new ExpenditureItems { ExpenditureItemsID = 43, AccountNumber = 2210709, Description = "Seminars/Conferences/Workshops/Meetings Expenses" },
                new ExpenditureItems { ExpenditureItemsID = 44, AccountNumber = 2210710, Description = "Staff Development" },
                new ExpenditureItems { ExpenditureItemsID = 45, AccountNumber = 2731102, Description = "Staff Welfare Expenses" },
                new ExpenditureItems { ExpenditureItemsID = 46, AccountNumber = 2210117, Description = "Teaching & Learning Materials" },
                new ExpenditureItems { ExpenditureItemsID = 47, AccountNumber = 2210203, Description = "Telecommunications" },
                new ExpenditureItems { ExpenditureItemsID = 48, AccountNumber = 2210115, Description = "Textbooks & Library Books" },
                new ExpenditureItems { ExpenditureItemsID = 49, AccountNumber = 2210701, Description = "Training Materials" },
                new ExpenditureItems { ExpenditureItemsID = 7, AccountNumber = 2112242, Description = "Travel Allowance" },
                new ExpenditureItems { ExpenditureItemsID = 50, AccountNumber = 2210112, Description = "Uniform and Protective Clothing" },
                new ExpenditureItems { ExpenditureItemsID = 51, AccountNumber = 2210202, Description = "Water" }
                ));
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Departments> Departments { get; set; }

        public virtual DbSet<Expenditure> Expenditures { get; set; }

        public virtual DbSet<Cheques> Cheques { get; set; }

        public virtual DbSet<ExpenditureItems> ExpenditureItems { get; set; }
    }
}