using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Hall
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int TotalTables { get; set; }
        public int AvailableTables { get; set; }
        public ICollection<Profit> Profits { get; set; }
        public ICollection<Staff> StaffMembers { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
