using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IItemService
    {
        int CreateItem(Item item);
        int DeleteItem(string ID);
        List<Item> GetAllItems();
        Item getbyid(string ID);
        int UpdateItem(string ID, Item NewItem);
    }
}