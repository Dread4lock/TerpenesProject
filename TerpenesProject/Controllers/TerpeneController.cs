using Microsoft.AspNetCore.Mvc;

namespace TerpenesProject.Controllers
{
    public class TerpeneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
