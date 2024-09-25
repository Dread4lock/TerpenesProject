using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerpenesProject.Models;

public class TerpeneController : Controller
{
    private readonly TerpenesProjectDbContext _context;

    public TerpeneController(TerpenesProjectDbContext context)
    {
        _context = context;
    }

    // Метод для загрузки страницы с чекбоксами и таблицей
    public async Task<IActionResult> Index(List<int> selectedTerpenes = null)
    {
        var viewModel = new Terpene();

        // Получаем всех терпены для чекбоксов
        viewModel.AllTerpenes = await _context.Terpenes.ToListAsync();

        // Если есть выбранные терпены, отфильтровываем их
        if (selectedTerpenes != null && selectedTerpenes.Any())
        {
            viewModel.FilteredTerpenes = await _context.Terpenes
                .Where(t => selectedTerpenes.Contains(t.Id))
                .ToListAsync();
        }

        return View(viewModel);
    }

    // Метод для обработки фильтрации (срабатывает на нажатие кнопки "Filter")
    [HttpPost]
    public async Task<IActionResult> Filter(List<int> selectedTerpenes)
    {
        // Перенаправляем запрос на метод Index с выбранными терпинами
        return RedirectToAction("Index", new { selectedTerpenes });
    }


}
