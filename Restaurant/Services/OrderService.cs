using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestDBcontext context;

        public OrderService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Order> GetAllOrders()
        {
            return context.Order.ToList();
        }
        public Order getbyid(string ID)
        {
            return context.Order.FirstOrDefault(x => x.Id == ID);
        }
        public int CreateOrder(Order Order)
        {
            context.Order.Add(Order);
            return context.SaveChanges();
        }
        public int DeleteOrder(string ID)
        {
            var Order = context.Order.FirstOrDefault(x => x.Id == ID);
            context.Order.Remove(Order);
            return context.SaveChanges();
        }
        public int updateOrder(string ID, Order NewOrder)
        {
            var OldOrder = context.Order.FirstOrDefault(x => x.Id == ID);
            OldOrder.Staff = NewOrder.Staff;
            OldOrder.Table = NewOrder.Table;
            return context.SaveChanges();
        }
    }
}
