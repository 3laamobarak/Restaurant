using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderedItemsController : Controller
    {
        IOrdered_ItemsService ordered_ItemsService;
        public OrderedItemsController(IOrdered_ItemsService _ordered_ItemsService)
        {
            ordered_ItemsService = _ordered_ItemsService;
        }
        public IActionResult ShowOrderedItems(string id)
        {
            List<Ordered_Items> ordered_Items = ordered_ItemsService.GetAllOrdered_Itemss(id);
            return View(ordered_Items);
        }
        public IActionResult AddOrderedItems()
        {
            return View();
        }
        public IActionResult SaveAddOrderedItems(Ordered_Items ordered_Items)
        {
            if(ModelState.IsValid)
            {
                ordered_ItemsService.CreateOrdered_Items(ordered_Items);
                return RedirectToAction("ShowOrderedItems");
            }
            return View("AddOrderedItems",ordered_Items);
        }
        public IActionResult Edit(string ID)
        {
            Ordered_Items ordered_Items = ordered_ItemsService.getbyid(ID);
            return View(ordered_Items);
        }
        public IActionResult SaveEditOrderedItems([FromRoute]string id,Ordered_Items newordered_Items)
        {
            ordered_ItemsService.UpdateOrdered_Items(id,newordered_Items);
            return RedirectToAction("ShowOrderedItems");
        }
        public IActionResult Delete(string ID)
        {
            ordered_ItemsService.DeleteOrdered_Items(ID);
            return RedirectToAction("ShowOrderedItems");
        }

    }
}
