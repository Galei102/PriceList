using TestPriceList.ViewModels;

namespace TestPriceList.Models
{
    public class ValueColumn
    {
        public int Id { get; set; }
        // TODO: rename VALUE
        public string Name { get; set; }
        public int ColumnId { get; set; }
        public Column Column { get; set; }
        public int? TovarId { get; set; }
        public Tovar Tovar { get; set; }
    }
}
