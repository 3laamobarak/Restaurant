using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService staffService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHallService hallService;

        public StaffController(IStaffService _staffService,IWebHostEnvironment _webHostEnvironment,IHallService _hallService)
        {
            staffService = _staffService;
            webHostEnvironment = _webHostEnvironment;
            hallService = _hallService;
        }
        public IActionResult showallstaff()
        {
            List<Staff> staff = staffService.GetAllStaff();
            return View(staff);
        }
        public IActionResult AddStaff()
        {
            List<Hall> hall = hallService.GetAllHall();
            ViewData["Hall"]= hall;
            return View();
        }
        public async Task<IActionResult> SaveAddStaff(Staff staff)
        {
            Hall Hall = hallService.getbyid(staff.HallId);
            staff.Hall = Hall;
            List<Hall> hall = hallService.GetAllHall();
            if (ModelState.IsValid)
            {
                if (staff.Image != null)
                {
                    string folder = "Images\\Staff";
                    string fileName = Guid.NewGuid().ToString() + "_" + staff.Image.FileName;
                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder, fileName);
                    await staff.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    // Save the image path to the staff object  
                    staff.ImagePath = Path.Combine(folder, fileName); // Store the relative path for the database  
                }
                staffService.CreateStaff(staff);
                return RedirectToAction("showallstaff");
            }
            return View("AddStaff", staff);
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
