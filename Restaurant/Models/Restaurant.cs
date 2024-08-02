using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Restaurant
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }
        public ICollection<Hall> Halls { get; set; }
    }
}
