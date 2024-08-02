using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Profit
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        [ForeignKey("Hall")]
        public string HallId { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
