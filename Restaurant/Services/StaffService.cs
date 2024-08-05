using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class StaffService : IStaffService
    {
        private readonly RestDBcontext context;
        public StaffService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Staff> GetAllStaff()
        {
            return context.Staff.ToList();
        }
        public Staff getbyid(string ID)
        {
            return context.Staff.FirstOrDefault(x => x.Id == ID);
        }
        public int CreateStaff(Staff staff)
        {
            context.Staff.Add(staff);
            return context.SaveChanges();
        }
        public int UpdateStaff(string ID, Staff NewStaff)
        {
            var oldstaff = context.Staff.FirstOrDefault(x => x.Id == ID);
            oldstaff.NID = NewStaff.NID;
            oldstaff.Name = NewStaff.Name;
            oldstaff.Address = NewStaff.Address;
            oldstaff.Phone = NewStaff.Phone;
            oldstaff.Image = NewStaff.Image;
            oldstaff.HolidaysTaken = NewStaff.HolidaysTaken;
            oldstaff.BaseSalary = NewStaff.BaseSalary;
            oldstaff.Bonus = NewStaff.Bonus;
            oldstaff.DeductedDays = NewStaff.DeductedDays;
            oldstaff.Hall = NewStaff.Hall;
            oldstaff.Manager = NewStaff.Manager;
            oldstaff.Type = NewStaff.Type;
            return context.SaveChanges();
        }
        public int DeleteStaff(string ID)
        {
            var staff = context.Staff.FirstOrDefault(x => x.Id == ID);
            context.Staff.Remove(staff);
            return context.SaveChanges();
        }
    }
}
