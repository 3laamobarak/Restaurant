using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class Ordered_ItemsService : IOrdered_ItemsService
    {
        private readonly RestDBcontext context;

        public Ordered_ItemsService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Ordered_Items> GetAllOrdered_Itemss()
        {
            return context.Ordered_Items.ToList();
        }
        public Ordered_Items getbyid(string ID)
        {
            return context.Ordered_Items.FirstOrDefault(x => x.Id == ID);
        }
        public int CreateOrdered_Items(Ordered_Items Ordered_Items)
        {
            context.Ordered_Items.Add(Ordered_Items);
            return context.SaveChanges();
        }
        public int DeleteOrdered_Items(string ID)
        {
            var Ordered_Items = context.Ordered_Items.FirstOrDefault(x => x.Id == ID);
            context.Ordered_Items.Remove(Ordered_Items);
            return context.SaveChanges();
        }
        public int UpdateOrdered_Items(string ID, Ordered_Items NewOrdered_Items)
        {
            var OldOrdered_Items = context.Ordered_Items.FirstOrDefault(x => x.Id == ID);
            OldOrdered_Items.Quantity = NewOrdered_Items.Quantity;
            OldOrdered_Items.Price = NewOrdered_Items.Price;
            OldOrdered_Items.Order = NewOrdered_Items.Order;
            OldOrdered_Items.Item = NewOrdered_Items.Item;
            return context.SaveChanges();
        }
    }
}
