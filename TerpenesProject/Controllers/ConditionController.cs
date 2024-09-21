using Microsoft.AspNetCore.Mvc;

namespace TerpenesProject.Controllers
{
    public class ConditionController : Controller
    {
        private readonly TerpenesProjectDbContext _context;

        public ConditionController(TerpenesProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
