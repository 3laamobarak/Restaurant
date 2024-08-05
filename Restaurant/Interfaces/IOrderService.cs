using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IOrderService
    {
        int CreateOrder(Order Order);
        int DeleteOrder(string ID);
        List<Order> GetAllOrders();
        Order getbyid(string ID);
        int updateOrder(string ID, Order NewOrder);
    }
}