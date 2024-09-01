﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Data.Enums;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class HallController : Controller
    {
        private readonly IHallService hallService;
        private readonly ITableService tableService;
        public HallController(IHallService _hallService,ITableService _tableService)
        {
            hallService = _hallService;
            tableService = _tableService;
        }
        public IActionResult ShowHalls(string id)
        {
            ViewData["RESTID"] = id;
            List<Hall> hallRest = hallService.GetAllHallofRestaurant(id);
            return View(hallRest);
        }
        public IActionResult AddHall(string RESTID)
        {
            ViewData["RESTID"] = RESTID;
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
                return RedirectToAction("ShowHalls");
            }
            return View("AddHall",hall);
        }
        public IActionResult Edit(string ID,int totaltable)
        {
            Hall hall = hallService.getbyid(ID);
            return View(hall);
        }
        public IActionResult SaveEditHall([FromRoute]string id,Hall newhall,int totaltable)
        {
            tableService.DeleteAll(newhall.Id);
            
            hallService.UpdateHall(id,newhall);
            for(int i=1;i<=newhall.TotalTables;i++)
            {
                Table table=new Table();
                table.Id=Guid.NewGuid().ToString();
                table.Number = i;
                table.Status = TableStatus.Free;
                table.Cash = 0.0;
                table.HallId = newhall.Id;
                tableService.AddTable(table);
            }
            return RedirectToAction("ShowHalls");
        }
        public IActionResult Delete(string ID)
        {
            Hall hall = hallService.getbyid(ID);
            string id = hall.RestaurantID;
            hallService.DeleteHall(ID);
            return RedirectToAction("ShowHalls",id);
        }
    }
}
