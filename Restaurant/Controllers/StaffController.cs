using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class StaffController : Controller
    {
        IStaffService staffService;
        public StaffController(IStaffService _staffService)
        {
            staffService = _staffService;
        }
        public IActionResult showstaff()
        {
            List<Staff> staff = staffService.GetAllStaff();
            return View(staff);
        }
        public IActionResult AddStaff()
        {
            return View();
        }
        public IActionResult SaveAddStaff(Staff staff)
        {
            if(ModelState.IsValid)
            {
                staffService.CreateStaff(staff);
                return RedirectToAction("showstaff");
            }
            return View("AddStaff",staff);
        }
        public IActionResult Edit(string ID)
        {
            Staff staff = staffService.getbyid(ID);
            return View(staff);
        }
        public IActionResult SaveEditStaff([FromRoute]string id,Staff newstaff)
        {
            staffService.UpdateStaff(id,newstaff);
            return RedirectToAction("showstaff");
        }
        public IActionResult Delete(string ID)
        {
            staffService.DeleteStaff(ID);
            return RedirectToAction("showstaff");
        }
    }
}
