using System.ComponentModel.DataAnnotations;
using TestPriceList.Models;

namespace TestPriceList.ViewModels
{
    public class PriceListViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
        public string Name { get; set; }
        public List<ColumnViewModel>? Columns { get; set; }
    }
}
