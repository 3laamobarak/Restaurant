using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class StorageRoom
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }
    }
}
