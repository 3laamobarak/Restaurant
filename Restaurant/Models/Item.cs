using MS.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Available { get; set; }
        public double Price { get; set; }
        public string Amount { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<StorageRoom> StorageRooms { get; set; }
        public ICollection<Ordered_Items> OrderedItems { get; set; }
    }
}
