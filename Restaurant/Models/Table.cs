using MS.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Table
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Number { get; set; }
        public double Cash { get; set; }
        public TableStatus Status { get; set; } = TableStatus.Free;

        [ForeignKey("Hall")]
        public string HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
