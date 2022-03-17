namespace TestPriceList.Models
{
    public class Column
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; }
        public string Name { get; set; }
        public ColumnTypes Types { get; set; }

    }
}
