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
    }
}
