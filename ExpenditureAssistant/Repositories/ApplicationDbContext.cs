using ExpenditureAssistant.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Repositories
{
    internal class ApplicationDbContext<T>:DbContext
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}