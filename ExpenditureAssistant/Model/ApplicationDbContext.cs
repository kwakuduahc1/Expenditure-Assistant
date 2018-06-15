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
                new Departments { Department = " Administration", DepartmentsID = 5 },
                new Departments { Department = "Stores/Procurement", DepartmentsID = 6 },
                new Departments { Department = "Kitchen", DepartmentsID = 7 },
                new Departments { Department = "Estate", DepartmentsID = 8 },
                new Departments { Department = "SRC", DepartmentsID = 9 },
                new Departments { Department = "Entertainment", DepartmentsID = 10 },
                new Departments { Department = "Exams Unit", DepartmentsID = 11 },
                new Departments { Department = "Psycho-motor Unit", DepartmentsID = 12 },
                new Departments { Department = "Nutrition", DepartmentsID = 13 }
                ));
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Departments> Departments { get; set; }

        public virtual DbSet<Expenditure> Expenditures { get; set; }

        public virtual DbSet<Cheques> Cheques { get; set; }
    }
}