using Microsoft.EntityFrameworkCore;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestDBcontext context;
        public RestaurantService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Restaurant.Models.Restaurant> GetAllRestaurants()
        {
            return context.Restaurant.ToList();
        }
        public Restaurant.Models.Restaurant GetRestaurantById(string ID)
        {
            return context.Restaurant.FirstOrDefault(x => x.Id == ID);
        }
        public int CreateRestaurant(Restaurant.Models.Restaurant restaurant)
        {
            context.Restaurant.Add(restaurant);
            return context.SaveChanges();
        }
        public int UpdateRestaurant(string ID, Restaurant.Models.Restaurant NewRestaurant)
        {
            var oldRestaurant = context.Restaurant.FirstOrDefault(x => x.Id == ID);
            oldRestaurant.Name = NewRestaurant.Name;
            oldRestaurant.Address = NewRestaurant.Address;
            oldRestaurant.Mail = NewRestaurant.Mail;
            oldRestaurant.Phone = NewRestaurant.Phone;
            oldRestaurant.Image = NewRestaurant.Image;
            return context.SaveChanges();
        }
        public int DeleteRestaurant(string ID)
        {
            List<Hall> halls = context.Hall.Include(s=>s.Restaurant).Where(s => s.RestaurantID == ID).ToList();
            var restaurant = context.Restaurant.FirstOrDefault(x => x.Id == ID);
            foreach (var item in halls)
            {
                context.Hall.Remove(item);
            }
            context.Restaurant.Remove(restaurant);
            return context.SaveChanges();
        }


    }
}
