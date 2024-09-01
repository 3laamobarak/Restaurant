using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IHallService
    {
        int AddHall(Hall hall);
        int DeleteHall(string ID);
        List<Hall> GetAllHall();
        List<Hall> GetAllHallofRestaurant(string ID);
        Hall getbyid(string ID);
        int UpdateHall(string ID, Hall Newhall);
    }
}