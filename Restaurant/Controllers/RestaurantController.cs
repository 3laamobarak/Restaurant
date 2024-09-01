using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        IRestaurantService restaurantService;
        public RestaurantController(IRestaurantService _restaurantService)
        {
            restaurantService = _restaurantService;
        }
        public IActionResult ShowRestaurants()
        {
            List<Restaurant.Models.Restaurant> restaurants =restaurantService.GetAllRestaurants();
            return View(restaurants);
        }
        public IActionResult AddRestaurant()
        {
            return View();
        }
        public IActionResult SaveAddedRestaurant(Restaurant.Models.Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                restaurantService.CreateRestaurant(restaurant);
                return RedirectToAction("ShowRestaurants");
            }
            return View("AddRestaurant",restaurant);
        }
        public IActionResult Edit(string ID)
        {
            Restaurant.Models.Restaurant restaurant = restaurantService.GetRestaurantById(ID);
            return View(restaurant);
        }
        public IActionResult SaveEdit([FromRoute]string id,Restaurant.Models.Restaurant newrest)
        {
            restaurantService.UpdateRestaurant(id,newrest);
            return RedirectToAction("ShowRestaurants");
        }
        public IActionResult Delete(string ID)
        {
            restaurantService.DeleteRestaurant(ID);
            return RedirectToAction("ShowRestaurants");
        }
    }
}
