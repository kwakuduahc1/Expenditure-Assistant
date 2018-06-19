using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ExpenditureAssistant.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Controllers
{
    public class ExpenditureItemsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ExpenditureItemsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List()
        {
            var list = await new ApplicationDbContext(dco).ExpenditureItems.Select(x => new { x.ExpenditureItemsID, x.AccountNumber, x.Description }).OrderBy(x => x.Description).ToListAsync();
            return list;
        }

        //[HttpPost]
        //public async Task<IEnumerable> History([FromBody]SearchDepartment search)
        //{
        //    using (var db = new ApplicationDbContext(dco))
        //    {
        //        var res = await db.Expenditures
        //            .Where(x => x.DepartmentsID == search.ID && x.DateDone.Year == search.Year && x.DateDone.Month >= search.Month)
        //            .Take(search.Fetch)
        //            .Skip(search.Offset)
        //            .Select(x => new { x.DateDone, x.Amount, x.Cheques.ChequeNumber, x.Item, x.PVNumber, x.Cheques.Status })
        //            .ToListAsync();
        //        return res;
        //    }
        //}

        //[HttpGet]
        //public async Task<IEnumerable> Summary(int year, byte month) =>
        //    await new ApplicationDbContext(dco).Expenditures
        //    .Where(x => x.DateDone.Year == year && x.DateDone.Month <= (month + 12))
        //    .GroupBy(x => x.Departments.Department, (k, v) => new
        //    {
        //        Department = k,
        //        Amount = v.Sum(x => x.Amount)
        //    })
        //    .ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var item = await new ApplicationDbContext(dco).ExpenditureItems.FindAsync(id);
            return item == null ? (IActionResult)NotFound(new { Message = "Department not found" }) : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ExpenditureItems exp)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.ExpenditureItems.AnyAsync(x => x.Description == exp.Description))
                    return BadRequest(new { Message = "Item already exists" });
                db.Add(exp);
                await db.SaveChangesAsync();
                return Created($"/ExpenditureItems/Find?id={exp.ExpenditureItemsID}", exp);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]ExpenditureItems exp)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.ExpenditureItems.AnyAsync(x => x.ExpenditureItemsID == exp.ExpenditureItemsID))
                    return BadRequest(new { Message = "Item does not exists" });
                db.Entry(exp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(exp);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]ExpenditureItems exp)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.ExpenditureItems.AnyAsync(x => x.ExpenditureItemsID == exp.ExpenditureItemsID))
                    return BadRequest(new { Message = "Department does not exists" });
                db.Entry(exp).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(exp);
            }
        }
    }
}