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
        var hall = context.Hall.FirstOrDefault(s => s.Id == ID);
        context.Hall.Remove(hall);
        return context.SaveChanges();
    }
}