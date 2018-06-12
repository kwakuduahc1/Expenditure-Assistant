using ExpenditureAssistant.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenditureAssistant.Repositories
{
    public class DepartmentsRepos<T>
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public DepartmentsRepos(DbContextOptions<ApplicationDbContext> options) => dco = options;

        public async Task<IEnumerable<T>> DepartmentsList() => await Task.Run(() => new ApplicationDbContext<T>(dco).Model.AsEnumerable());

        public async Task<Departments> Find(int id) => await Task.Run(() => new ApplicationDbContext(dco).Departments.FindAsync(id));

        public async Task<object> Create()
    }
}
