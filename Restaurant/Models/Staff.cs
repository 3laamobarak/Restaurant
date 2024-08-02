using MS.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }
        public int NID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int Holidays { get; set; }
        public double BaseSalary { get; set; }
        public double Bonus { get; set; }
        public int DeductedDays { get; set; }
        public double Salary { get; set; }
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
