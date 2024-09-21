using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerpenesProject.Models;

namespace TerpenesProject.Controllers
{
    public class ConditionController : Controller
    {
        private readonly TerpenesProjectDbContext _context;

        public ConditionController(TerpenesProjectDbContext context)
        {
            _context = context;
        }

        // Метод для загрузки страницы с состояниями и связанными терпенами
        public async Task<IActionResult> Index(List<Guid> selectedConditions = null)
        {
            var viewModel = new Condition();

            // Получаем все состояния и связанные с ними терпены через TerpeneCondition
            viewModel.AllConditions = await _context.Conditions
                .Include(c => c.TerpeneConditions)
                .ThenInclude(tc => tc.Terpene)
                .ToListAsync();

            // Если есть выбранные состояния, отфильтровываем связанные терпены
            if (selectedConditions != null && selectedConditions.Any())
            {
                viewModel.FilteredTerpenes = await _context.Terpenes
                    .Where(t => t.TerpeneConditions
                        .Any(tc => selectedConditions.Contains(tc.ConditionId)))
                    .ToListAsync();
            }

            return View(viewModel);
        }

        // Метод для обработки фильтрации (срабатывает на нажатие кнопки "Filter")
        [HttpPost]
        public async Task<IActionResult> Filter(List<Guid> selectedConditions)
        {
            // Перенаправляем запрос на метод Index с выбранными состояниями
            return RedirectToAction("Index", new { selectedConditions });
        }
    }
}
