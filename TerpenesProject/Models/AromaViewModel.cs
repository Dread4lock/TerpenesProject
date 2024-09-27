using System.Collections.Generic;
using TerpenesProject.Models;

namespace TerpenesProject.Models
{
    public class AromaViewModel
    {
        // Уникальные ароматы для отображения в чекбоксах
        public List<string> AllAromas { get; set; }

        // Отфильтрованные терпены для отображения на странице
        public List<Terpene> FilteredTerpenes { get; set; }

        // Список для связанных условий
        public Dictionary<Terpene, List<Condition>> TerpeneConditions { get; set; } = new Dictionary<Terpene, List<Condition>>();
    }
}
