using System.ComponentModel.DataAnnotations;

namespace TestPriceList.Models
{
    public class PriceList
    {
        [Display(Name = "№")]
        public int Id { get; set; }


        [Display(Name = "Название")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
        public string Name { get; set; }
    }
}
