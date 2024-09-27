using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerpenesProject.Models;

namespace TerpenesProject.Controllers
{
    public class AromaController : Controller
    {
        private readonly TerpenesProjectDbContext _context;

        public AromaController(TerpenesProjectDbContext context)
        {
            _context = context;
        }

        // Метод для загрузки страницы с ароматами
        public async Task<IActionResult> Index(List<string> selectedAromas = null)
        {
            var viewModel = new AromaViewModel();

            var allTerpenes = await _context.Terpenes
                .Include(t => t.TerpeneConditions)
                .ThenInclude(tc => tc.Condition)
                .ToListAsync();

            viewModel.AllAromas = allTerpenes
                .SelectMany(t => t.Aroma.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                .Distinct()
                .ToList();

            if (selectedAromas != null && selectedAromas.Any())
            {
                viewModel.FilteredTerpenes = allTerpenes
                    .Where(t => selectedAromas.Any(a => t.Aroma.Contains(a)))
                    .ToList();

                // Для каждого терпена добавляем связанные с ним условия
                foreach (var terpene in viewModel.FilteredTerpenes)
                {
                    var conditions = terpene.TerpeneConditions.Select(tc => tc.Condition).ToList();
                    viewModel.TerpeneConditions[terpene] = conditions;
                }
            }

            return View(viewModel);
        }



        // Метод для фильтрации терпенов по ароматам
        [HttpPost]
        public async Task<IActionResult> Filter(List<string> selectedAromas)
        {
            return RedirectToAction("Index", new { selectedAromas });
        }
    }
}
