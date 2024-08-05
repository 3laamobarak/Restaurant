using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IHallService
    {
        int AddHall(Hall hall);
        int DeleteHall(string ID);
        List<Hall> GetAllHall();
        Hall getbyid(string ID);
        int UpdateHall(string ID, Hall Newhall);
    }
}