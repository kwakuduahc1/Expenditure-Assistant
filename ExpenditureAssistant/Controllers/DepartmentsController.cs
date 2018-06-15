using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ExpenditureAssistant.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public DepartmentsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Departments.Select(x => new { x.DepartmentsID, x.Department, x.Concurrency, Amount = x.Expenditure.Sum(t => t.Amount) }).ToListAsync();

        [HttpPost]
        public async Task<IEnumerable> History([FromBody]SearchDepartment search)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var res = await db.Expenditures
                    .Where(x => x.DepartmentsID == search.ID && x.DateDone.Year == search.Year && x.DateDone.Month >= search.Month)
                    .Take(search.Fetch)
                    .Skip(search.Offset)
                    .Select(x => new { x.DateDone, x.Amount, x.Cheques.ChequeNumber, x.Item, x.PVNumber, x.Cheques.Status })
                    .ToListAsync();
                return res;
            }
        }

        [HttpGet]
        public async Task<IEnumerable> Summary(int year, byte month) =>
            await new ApplicationDbContext(dco).Expenditures
            .Where(x => x.DateDone.Year == year && x.DateDone.Month <= (month + 12))
            .GroupBy(x => x.Departments.Department, (k, v) => new
            {
                Department = k,
                Amount = v.Sum(x => x.Amount)
            })
            .ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var dept = await new ApplicationDbContext(dco).Departments.FindAsync(id);
            return dept == null ? (IActionResult)NotFound(new { Message = "Department not found" }) : Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Departments dept)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.Departments.AnyAsync(x => x.Department == dept.Department))
                    return BadRequest(new { Message = "Department already exists" });
                db.Add(dept);
                await db.SaveChangesAsync();
                return Created($"/Departments/Find?id={dept.DepartmentsID}", dept);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]Departments dept)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Departments.AnyAsync(x => x.DepartmentsID == dept.DepartmentsID))
                    return BadRequest(new { Message = "Department does not exists" });
                db.Entry(dept).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(dept);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Departments dept)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Departments.AnyAsync(x => x.DepartmentsID == dept.DepartmentsID))
                    return BadRequest(new { Message = "Department does not exists" });
                db.Entry(dept).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(dept);
            }
        }
    }
}
