using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService _itemService)
        {
            itemService = _itemService;
        }
        public IActionResult ShowItems()
        {
            List<Item> items = itemService.GetAllItems();
            return View(items);
        }
        public IActionResult AddItem()
        {
            return View();
        }
        public IActionResult SaveAddItem(Item item)
        {
            if(ModelState.IsValid)
            {
                itemService.CreateItem(item);
                return RedirectToAction("showitems");
            }
            return View("additem",item);
        }
        public IActionResult Edit(string id)
        {
            Item item = itemService.getbyid(id);
            return View(item);
        }
        public IActionResult SaveEdit([FromRoute] string id, Item newitem)
        {
            itemService.UpdateItem(id, newitem);
            return RedirectToAction("Showitems");
        }
        public IActionResult Delete(string id)
        {
            itemService.DeleteItem(id);
            return RedirectToAction("showitems");
        }
    }
}
