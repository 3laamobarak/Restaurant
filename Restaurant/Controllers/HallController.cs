using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;

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
            hallService.GetAllHall();
            return View();
        }



    }
}
