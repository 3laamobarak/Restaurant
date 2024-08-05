using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IOrdered_ItemsService
    {
        int CreateOrdered_Items(Ordered_Items Ordered_Items);
        int DeleteOrdered_Items(string ID);
        List<Ordered_Items> GetAllOrdered_Itemss();
        Ordered_Items getbyid(string ID);
        int UpdateOrdered_Items(string ID, Ordered_Items NewOrdered_Items);
    }
}