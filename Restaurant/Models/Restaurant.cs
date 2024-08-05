using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Restaurant
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public string? Image { get; set; }
        public ICollection<Hall> Halls { get; set; }
    }
}
