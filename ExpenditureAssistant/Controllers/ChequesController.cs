using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ExpenditureAssistant.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Controllers
{
    public class ChequesController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ChequesController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Cheques.Select(x => new { x.Amount, x.ChequeNumber, x.ChequesID, x.DateIssued}).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(int id)
        {
            var dept = await new ApplicationDbContext(dco).Cheques.FindAsync(id);
            return dept == null ? (IActionResult)NotFound(new { Message = "Department not found" }) : Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Cheques chq)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.Cheques.AnyAsync(x => x.ChequeNumber == chq.ChequeNumber))
                    return BadRequest(new { Message = "Cheque already exists" });
                var date = DateTime.UtcNow;
                chq.DateIssued = date;
                chq.Expenditures.ToList().ForEach(t => t.DateDone = date);
                db.Add(chq);
                await db.SaveChangesAsync();
                return Created($"/Cheques/Find?id={chq.ChequesID}", new { chq.Amount, chq.ChequesID, chq.DateIssued, chq.ChequeNumber });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]Cheques chq)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Cheques.AnyAsync(x => x.ChequesID == chq.ChequesID))
                    return BadRequest(new { Message = "Department does not exists" });
                db.Entry(chq).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(chq);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Cheques chq)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).ToList() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (!await db.Cheques.AnyAsync(x => x.ChequesID == chq.ChequesID))
                    return BadRequest(new { Message = "Department does not exists" });
                db.Entry(chq).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok(chq);
            }
        }
    }
}
