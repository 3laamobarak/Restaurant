using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IStaffService
    {
        int CreateStaff(Staff staff);
        int DeleteStaff(string ID);
        List<Staff> GetAllStaff();
        Staff getbyid(string ID);
        int UpdateStaff(string ID, Staff NewStaff);
    }
}