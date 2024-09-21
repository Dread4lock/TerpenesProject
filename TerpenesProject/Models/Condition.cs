using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerpenesProject.Models
{
    [Table("Conditions")]
    public class Condition
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Связь с таблицей TerpeneCondition
        public ICollection<TerpeneCondition> TerpeneConditions { get; set; }

        // Все состояния для чекбоксов
        public List<Condition> AllConditions { get; set; }

        // Отфильтрованные состояния, которые показываются в таблице
        public List<Condition> FilteredConditions { get; set; }

        // Отфильтрованные терпены, которые показываются в таблице
        public List<Terpene> FilteredTerpenes { get; set; }
    }
}
