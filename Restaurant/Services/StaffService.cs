using Microsoft.EntityFrameworkCore;
using MS.Data.Enums;
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
        public List<Staff> GetAllStaffWithManager(string id)
        {
            return context.Staff.Include(s => s.Hall).Where(s => s.Manager.Id == id).ToList();
        }
        public List<Staff> GetAllManager()
        {
            return context.Staff.Include(s=>s.Hall).Where(s=>s.Type ==MS.Data.Enums.StaffType.Manager).ToList();
        }
        public List<Staff> GetAllStaff()
        {
            return context.Staff.Include(s => s.Hall).ToList();
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
            bool isstillmanager = true;
            var oldstaff = context.Staff.FirstOrDefault(x => x.Id == ID);
            if(oldstaff.Type!=NewStaff.Type && oldstaff.Type==StaffType.Manager)
            {
                isstillmanager=false;
            }
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
            oldstaff.HallId = NewStaff.HallId;
            oldstaff.Manager = NewStaff.Manager;
            oldstaff.ManagerId = NewStaff.ManagerId;
            oldstaff.Type = NewStaff.Type;
            if(isstillmanager!=true)
            {
                List<Staff> LiStaff = GetAllStaffWithManager(ID);
                foreach (var item in LiStaff)
                {
                    item.ManagerId = null;
                }
            }
            return context.SaveChanges();
        }
        public int DeleteStaff(string ID)
        {
            List<Staff> LiStaff = GetAllStaffWithManager(ID);
            foreach(var item in LiStaff)
            {
                item.ManagerId = null;
            }
            var staff = context.Staff.FirstOrDefault(x => x.Id == ID);
            context.Staff.Remove(staff);
            return context.SaveChanges();
        }
    }
}
