using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IReceiptService
    {
        int CreateReceipt(Receipt receipt);
        int DeleteReceipt(string id);
        List<Receipt> GetAllReceipts();
        Receipt getbyId(string id);
        int UpdateReceipt(string ID, Receipt Newreceipt);
    }
}