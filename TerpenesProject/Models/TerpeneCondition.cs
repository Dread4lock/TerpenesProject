using System.ComponentModel.DataAnnotations.Schema;

namespace TerpenesProject.Models
{
    [Table("TerpenesConditions")]
    public class TerpeneCondition
    {
        public Guid TerpeneId { get; set; }
        public required Terpene Terpene { get; set; }

        public Guid ConditionId { get; set; }
        public required Condition Condition { get; set; }
    }
}
