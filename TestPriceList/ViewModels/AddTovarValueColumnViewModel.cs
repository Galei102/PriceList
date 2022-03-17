using System.ComponentModel.DataAnnotations;
using TestPriceList.Models;

namespace TestPriceList.ViewModels
{
    public class AddTovarValueColumnViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        public string TovarName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public int KodTovar { get; set; }

        public IEnumerable<ColumnValueViewModel> ColumnValues { get; set; }
    }

    public class ColumnValueViewModel
    {
        public int ColumnId { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Value { get; set; }
        
    }
}
