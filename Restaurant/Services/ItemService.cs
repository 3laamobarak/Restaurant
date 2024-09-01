using Microsoft.EntityFrameworkCore;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class ItemService : IItemService
    {
        private readonly RestDBcontext context;

        public ItemService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Item> GetAllItemSR(string id)
        {
            return context.Item.Include(s => s.StorageRoom).Where(s => s.StorageID == id).ToList();
        }
        public List<Item> GetAllItems()
        {
            return context.Item.ToList();
        }
        public Item getbyid(string ID)
        {
            return context.Item.FirstOrDefault(x => x.Id == ID);
        }
        public int CreateItem(Item item)
        {
            context.Item.Add(item);
            return context.SaveChanges();
        }
        public int UpdateItem(string ID, Item NewItem)
        {
            var olditem = context.Item.FirstOrDefault(x => x.Id == ID);
            olditem.Name = NewItem.Name;
            olditem.Type = NewItem.Type;
            olditem.Available = NewItem.Available;
            olditem.Price = NewItem.Price;
            olditem.Amount = NewItem.Amount;
            olditem.ExpireDate = NewItem.ExpireDate;
            return context.SaveChanges();
        }
        public int DeleteItem(string ID)
        {
            var item = context.Item.FirstOrDefault(x => x.Id == ID);
            context.Item.Remove(item);
            return context.SaveChanges();
        }
    }
}
