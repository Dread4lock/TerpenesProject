using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerpenesProject.Models
{
    [Table("TerpenesConditions")]
    public class TerpeneCondition
    {
        public int TerpeneId { get; set; }
        public Terpene Terpene { get; set; }

        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
    }
}
