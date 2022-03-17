using System.ComponentModel.DataAnnotations;

namespace TestPriceList.Models
{
    public class Tovar
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public virtual PriceList PriceList { get; set; }

        [Display(Name = "Название товара")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }

        [Display(Name = "Код товара")]
        [Required(ErrorMessage = "Заполните поле")]
        public int KodTovar { get; set; }

        public virtual IEnumerable<ValueColumn> Values { get; set; }
    }
}
