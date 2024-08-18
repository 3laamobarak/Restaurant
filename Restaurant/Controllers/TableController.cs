using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class TableController : Controller
    {
        ITableService tableService;
        public TableController(ITableService _itableService)
        {
            tableService = _itableService;
        }
        public IActionResult ShowTables(string id)
        {
            var tables = tableService.GetAllTables(id);
            return View(tables);
        }
        public IActionResult AddTable()
        {
            return View();
        }
        public IActionResult SaveAddTable(Table table)
        {
            if(ModelState.IsValid)
            {
                tableService.AddTable(table);
                return RedirectToAction("Showall");
            }
            return View("AddTable",table);
        }
        public IActionResult Edit(string id)
        {
            var table = tableService.GetById(id);
            return View(table);
        }
        public IActionResult SaveEditTable([FromRoute]int number, Table newtable)
        {
            tableService.UpdateTable(number, newtable);
            return RedirectToAction("Showall");
        }
        public IActionResult Delete(int number)
        {
            tableService.DeleteTable(number);
            return RedirectToAction("Showall");
        }


    }
}
