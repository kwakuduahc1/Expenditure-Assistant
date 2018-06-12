using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ExpenditureAssistant.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public DepartmentController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Departments.ToListAsync();

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
