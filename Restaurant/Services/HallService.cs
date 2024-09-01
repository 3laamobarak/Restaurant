using Microsoft.EntityFrameworkCore;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services;

public class HallService : IHallService
{
    private readonly RestDBcontext context;

    public HallService(RestDBcontext _context)
    {
        context = _context;
    }
    public List<Hall> GetAllHall()
    {
        return context.Hall.ToList();
    }
    public List<Hall> GetAllHallofRestaurant(string ID)
    {
        return context.Hall.Include(s => s.Restaurant).Where(s => s.RestaurantID == ID).ToList();
    }
    public Hall getbyid(string ID)
    {
        return context.Hall.FirstOrDefault(s => s.Id == ID);
    }
    public int AddHall(Hall hall)
    {
        context.Hall.Add(hall);
        return context.SaveChanges();
    }
    public int UpdateHall(string ID, Hall Newhall)
    {
        var oldhall = context.Hall.FirstOrDefault(s => s.Id == ID);
        oldhall.Name = Newhall.Name;
        oldhall.TotalTables = Newhall.TotalTables;
        oldhall.AvailableTables = Newhall.AvailableTables;
        return context.SaveChanges();
    }
    public int DeleteHall(string ID)
    {
        List<Staff> SLis = context.Staff.Include(s => s.Hall).Where(s=>s.Hall.Id==ID).ToList();
        var hall = context.Hall.FirstOrDefault(s => s.Id == ID);
        foreach(var item in SLis)
        { 
            item.Hall.Name = null;
        }
        context.Hall.Remove(hall);
        return context.SaveChanges();
    }
}