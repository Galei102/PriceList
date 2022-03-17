using System.ComponentModel.DataAnnotations;

namespace TestPriceList.Models
{
    public enum ColumnTypes
    {
        [Display(Name = "Число")]
        Number = 0,
        [Display(Name = "Однострочный текст")]
        SingleLineText = 1,
        [Display(Name = "Многострочный текст")]
        MultilineText = 2,
    }
}
