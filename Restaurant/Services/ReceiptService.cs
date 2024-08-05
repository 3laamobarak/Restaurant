using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly RestDBcontext context;
        public ReceiptService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Receipt> GetAllReceipts()
        {
            return context.Receipt.ToList();
        }
        public int CreateReceipt(Receipt receipt)
        {
            context.Receipt.Add(receipt);
            return context.SaveChanges();
        }
        public Receipt getbyId(string id)
        {
            return context.Receipt.FirstOrDefault(r => r.Id == id);
        }
        public int UpdateReceipt(string ID, Receipt Newreceipt)
        {
            var oldReceipt = context.Receipt.FirstOrDefault(r => r.Id == ID);
            oldReceipt.Amount = Newreceipt.Amount;
            oldReceipt.Total = Newreceipt.Total;
            oldReceipt.Table = Newreceipt.Table;
            oldReceipt.Order = Newreceipt.Order;
            return context.SaveChanges();
        }
        public int DeleteReceipt(string id)
        {
            var receipt = context.Receipt.FirstOrDefault(r => r.Id == id);
            context.Receipt.Remove(receipt);
            return context.SaveChanges();
        }
    }
}
