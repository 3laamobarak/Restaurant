using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MakingOrderViewModel
    {
        [Required]
        public string ItemName { get; set; }
        // number of items ordered
        public int Amount { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime OrderTime { get; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public int TableNumber {get; set;}
        [Required]
        public string HallName { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public Type tableStatue { get; set; }
    }
}
