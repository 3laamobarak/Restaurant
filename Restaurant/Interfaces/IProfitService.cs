using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface IProfitService
    {
        int AddProfit(Profit profit);
        int DeleteProfit(string ID);
        Profit getbyID(string ID);
        List<Profit> GetProfits();
        int UpdateProfit(string ID, Profit Newprofit);
    }
}