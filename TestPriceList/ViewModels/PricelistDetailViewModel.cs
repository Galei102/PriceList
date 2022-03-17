using TestPriceList.Models;

namespace TestPriceList.ViewModels
{
    public class PricelistDetailViewModel
    {
        public IEnumerable<Column> Columns { get; set; }
        public IEnumerable<Tovar> Tovars { get; set; }
    }
}
