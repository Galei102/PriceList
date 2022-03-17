using System.ComponentModel.DataAnnotations;
using TestPriceList.Models;

namespace TestPriceList.ViewModels
{
    public class ListEditTovarValuesViewModel
    {
        public Tovar Tovars { get; set; }
        public List<ValueColumn> ValueColumns { get; set; }
        public List <Column>? Column { get; set; }
    }
}
