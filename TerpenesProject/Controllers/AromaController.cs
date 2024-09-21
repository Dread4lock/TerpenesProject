using Microsoft.AspNetCore.Mvc;

namespace TerpenesProject.Controllers
{
    public class AromaController : Controller
    {
        private readonly TerpenesProjectDbContext _context;

        public AromaController(TerpenesProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
