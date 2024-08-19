using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class TableService : ITableService
    {
        private readonly RestDBcontext context;
        public TableService(RestDBcontext _context)
        {
            context = _context;
        }
        public List<Table> GetAllTables(string hallid)
        {
            return context.Table.Where(t=>t.HallId==hallid).OrderBy(t=>t.Number).ToList();
        }
        public Table GetById(string id)
        {
            return context.Table.FirstOrDefault(t => t.Id == id);
        }
        public Table GetByNumber(int number)
        {
            return context.Table.FirstOrDefault(t => t.Number == number);
        }
        public int AddTable(Table table)
        {
            context.Table.Add(table);
            return context.SaveChanges();
        }
        public int UpdateTable(int number, Table Newtable)
        {
            Table Oldtable = GetByNumber(number);
            Oldtable.Number = Newtable.Number;
            Oldtable.Cash = Newtable.Cash;
            Oldtable.Status = Newtable.Status;
            Oldtable.Hall = Newtable.Hall;
            return context.SaveChanges();
        }
        public int DeleteTable(int number)
        {
            Table table = GetByNumber(number);
            context.Table.Remove(table);
            return context.SaveChanges();
        }
        public int DeleteAll(string hallid)
        {
            List<Table> table = context.Table.Where(t=>t.HallId==hallid).ToList();
            context.Table.RemoveRange(table);
            return context.SaveChanges();
        }

    }
}
