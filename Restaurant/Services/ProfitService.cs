using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class ProfitService : IProfitService
    {
        private readonly RestDBcontext context;

        public ProfitService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Profit> GetProfits()
        {
            return context.Profit.ToList();
        }
        public Profit getbyID(string ID)
        {
            Profit profit = context.Profit.FirstOrDefault(x => x.Id == ID);
            return profit;
        }
        public int AddProfit(Profit profit)
        {
            context.Profit.Add(profit);
            return context.SaveChanges();
        }
        public int DeleteProfit(string ID)
        {
            Profit profit = context.Profit.FirstOrDefault(x => x.Id == ID);
            context.Profit.Remove(profit);
            return context.SaveChanges();
        }
        public int UpdateProfit(String ID, Profit Newprofit)
        {
            Profit Oldprofit = context.Profit.FirstOrDefault(x => x.Id == ID);
            Oldprofit.Amount = Newprofit.Amount;
            Oldprofit.Hall = Newprofit.Hall;
            return context.SaveChanges();
        }
    }
}
