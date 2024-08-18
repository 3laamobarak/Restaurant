using Restaurant.Models;

namespace Restaurant.Interfaces
{
    public interface ITableService
    {
        int AddTable(Table table);
        int DeleteTable(int number);
        List<Table> GetAllTables(string hallid);
        Table GetById(string id);
        Table GetByNumber(int number);
        int UpdateTable(int number, Table Newtable);
    }
}