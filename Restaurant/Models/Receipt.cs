using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Receipt
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        //[OrderPrice]
        public double Total { get; set; }

        [ForeignKey("Table")]
        public string TableId { get; set; }
        public virtual Table Table { get; set; }

        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
