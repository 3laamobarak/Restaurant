using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HallController : Controller
    {
        IHallService hallService;
        public HallController(IHallService _hallService)
        {
            hallService = _hallService;
        }
        public IActionResult ShowHalls()
        {
            List<Hall> hall =hallService.GetAllHall();
            return View(hall);
        }
        public IActionResult AddHall()
        {
            return View();
        }
        public IActionResult SaveAddHall(Hall hall)
        {
            if(ModelState.IsValid)
            {
                hallService.AddHall(hall);
                return RedirectToAction("showHalls");
            }
            return View("AddHall",hall);
        }
        public IActionResult Edit(string ID)
        {
            Hall hall = hallService.getbyid(ID);
            return View(hall);
        }
        public IActionResult SaveEditHall([FromRoute]string id,Hall newhall)
        {
            hallService.UpdateHall(id,newhall);
            return RedirectToAction("ShowHalls");
        }
        public IActionResult Delete(string ID)
        {
            hallService.DeleteHall(ID);
            return RedirectToAction("ShowHalls");
        }
    }
}
