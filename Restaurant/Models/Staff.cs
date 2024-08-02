using MS.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }
        [Required]
        //[NID]
        public int NID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        // [age calc with Nid]
        public int Age { get; set; }
        // try to make it with nid
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int HolidaysTaken { get; set; }
        public double BaseSalary { get; set; }
        public double Bonus { get; set; }
        public int DeductedDays { get; set; }
        //[CountedSalary]
        public double Salary { get; set; }
        [Required]
        public StaffType Type { get; set; }

        [ForeignKey("Hall")]
        public string HallId { get; set; }
        public Hall Hall { get; set; }

        [ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public Staff Manager { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
