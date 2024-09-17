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

        public ICollection<TerpeneCondition> TerpeneConditions { get; set; }
    }
}
