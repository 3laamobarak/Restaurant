using MS.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Restaurant.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Models
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }
        [Required][NID]
        public string NID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public int Age
        {
            get
            {
                if (NID == null)
                {
                    throw new ArgumentNullException(nameof(NID));
                }
                if (NID.Length >= 6 && int.TryParse(NID.Substring(1, 6), out int birthdate))
                {
                    int birthYear = birthdate / 10000;   
                    int birthMonth = (birthdate / 100) % 100;  
                    int birthDay = birthdate % 100;
                    int fullYear;
                    if (birthYear >= 0 && birthYear <= 99)
                    {
                        fullYear = (birthYear < 50) ? (2000 + birthYear) : (1900 + birthYear);
                    }
                    else
                    {
                        fullYear = birthYear;
                    }
                    int currentYear = DateTime.Now.Year;
                    int calculatedAge = currentYear - fullYear;
                    if (birthMonth > DateTime.Now.Month || (birthMonth == DateTime.Now.Month && birthDay > DateTime.Now.Day))
                    {
                        calculatedAge--;
                    }
                    return calculatedAge;
                }
                return 0;  
            }
        }
        public GenderType Gender 
        { 
            get
            {
                if(NID == null)
                {
                    throw new ArgumentNullException(nameof(NID));
                }
                char genderchar = NID[12];
                if(char.IsDigit(genderchar))
                {
                    int GenderNumber = int.Parse(genderchar.ToString());
                    return (GenderNumber % 2 == 1 )?GenderType.Male:GenderType.Female;
                }
                throw new ArgumentException("Enter the NID first");
            }
        }
        public string? Image { get; set; }
        public int HolidaysTaken { get; set; } = 0;
        public double BaseSalary { get; set; }
        public double Bonus { get; set; } = 0;
        public int DeductedDays { get; set; } = 0;
        public double Salary 
        {
            get
            {
                if(BaseSalary == null)
                {
                    throw new ArgumentNullException(nameof(BaseSalary));
                }
                int daysalary = (int)(BaseSalary / 30);
                BaseSalary -= (HolidaysTaken * daysalary);
                BaseSalary += Bonus;
                BaseSalary -= (DeductedDays * daysalary);
                return BaseSalary;
            }
        }
        [Required]
        public StaffType Type { get; set; }

        [ForeignKey("Hall")]
        public string HallId { get; set; }
        public Hall Hall { get; set; }

        [ForeignKey("Manager")]
        public string? ManagerId { get; set; }
        public Staff Manager { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
