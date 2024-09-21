using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerpenesProject.Models
{
    [Table("Terpenes")]
    public class Terpene
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Aroma { get; set; }

        // Связь с таблицей TerpeneCondition
        public ICollection<TerpeneCondition> TerpeneConditions { get; set; }

        // Все терпены для чекбоксов
        public List<Terpene> AllTerpenes { get; set; }

        // Отфильтрованные терпены, которые показываются в таблице
        public List<Terpene> FilteredTerpenes { get; set; }

        // Связь с таблицей Aroma через many-to-many
        public ICollection<Aroma> Aromas { get; set; }


    }
}
