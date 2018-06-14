using System.Diagnostics;
using System.Threading.Tasks;
using ExpenditureAssistant.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenditureAssistant.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> context;

        public HomeController(DbContextOptions<ApplicationDbContext> options) => context = options;

        public async Task<IActionResult> Index()
        {
            await new ApplicationDbContext(context).Database.EnsureCreatedAsync();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
