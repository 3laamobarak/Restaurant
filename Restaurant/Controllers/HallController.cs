using Microsoft.AspNetCore.Mvc;
using MS.Data.Enums;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallService hallService;
        private readonly ITableService tableService;
        public HallController(IHallService _hallService,ITableService _tableService)
        {
            hallService = _hallService;
            tableService = _tableService;
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
                for(int i = 1;i<=hall.TotalTables;i++)
                {
                    Table table = new Table();
                    table.Id=Guid.NewGuid().ToString();
                    table.Number = i;
                    table.Status = TableStatus.Free;
                    table.Cash = 0.0;
                    table.HallId = hall.Id;
                    tableService.AddTable(table);
                }
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
