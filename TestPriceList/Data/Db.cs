using Microsoft.EntityFrameworkCore;
using TestPriceList.Models;

namespace TestPriceList.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }

        public DbSet<Column> Columns { get; set; } 
        public DbSet<PriceList> PricesList { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<ValueColumn> ValuesColumn { get; set; }
    }
}
