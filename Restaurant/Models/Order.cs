using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public DateTime OrderTime { get; set; }

        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Table")]
        public string TableId { get; set; }
        public Table Table { get; set; }
        public virtual ICollection<Ordered_Items> OrderedItems { get; set; }
    }
}
