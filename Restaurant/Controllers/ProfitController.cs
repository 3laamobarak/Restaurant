using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class ProfitController : Controller
    {
        IProfitService profitservice;
        public ProfitController(IProfitService _profitservice)
        {
            profitservice = _profitservice;
        }
        public IActionResult ShowProfit()
        {
            List<Profit> profit = profitservice.GetProfits();
            return View(profit);
        }
        public IActionResult AddProfit()
        {
            return View();
        }
        public IActionResult SaveAddProfit(Profit profit)
        {
            if(ModelState.IsValid)
            {
                profitservice.AddProfit(profit);
                return RedirectToAction("ShowProfit");
            }
            return View("AddProfit",profit);
        }
        public IActionResult Edit(string ID)
        {
            Profit profit = profitservice.getbyID(ID);
            return View(profit);
        }
        public IActionResult SaveEditProfit([FromRoute]string id,Profit newprofit)
        {
            profitservice.UpdateProfit(id,newprofit);
            return RedirectToAction("ShowProfit");
        }
        public IActionResult Delete(string ID)
        {
            profitservice.DeleteProfit(ID);
            return RedirectToAction("ShowProfit");
        }
    }
}
