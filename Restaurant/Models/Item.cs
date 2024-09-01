using MS.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ItemType Type { get; set; }
        [Required]
        //[Available] //total amount - ordered amount
        public int Available { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        // number of items ordered
        public int Amount { get; set; }
        public DateTime ExpireDate { get; set; }
        [ForeignKey("StorageRoom")]
        public string? StorageID { get; set; }
        public StorageRoom? StorageRoom { get; set; }
        //public ICollection<StorageRoom> StorageRooms { get; set; }
        //public ICollection<Ordered_Items> OrderedItems { get; set; }
    }
}
