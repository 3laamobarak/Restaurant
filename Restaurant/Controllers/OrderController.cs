using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public IActionResult ShowOrders()
        {
            List<Order> order = orderService.GetAllOrders();
            return View(order);
        }
        public IActionResult AddOrder()
        {
            return View();
        }
        public IActionResult SaveAddOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                orderService.CreateOrder(order);
                return RedirectToAction("ShowOrders");
            }
            return View("AddOrder",order);
        }
        public IActionResult Edit(string ID)
        {
            Order order = orderService.getbyid(ID);
            return View(order);
        }
        public IActionResult SaveEditOrder([FromRoute]string id,Order neworder)
        {
            orderService.updateOrder(id,neworder);
            return RedirectToAction("ShowOrders");
        }
        public IActionResult Delete(string ID)
        {
            orderService.DeleteOrder(ID);
            return RedirectToAction("ShowOrders");
        }
    }
}
