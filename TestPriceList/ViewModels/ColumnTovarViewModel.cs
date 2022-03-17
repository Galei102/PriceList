using TestPriceList.Models;

namespace TestPriceList.ViewModels
{
    public class ColumnTovarViewModel
    {
        public IEnumerable<Column>? Columns { get; set; }
        public AddTovarValueColumnViewModel AddTovarValueColumn { get; set; }
    }
}
