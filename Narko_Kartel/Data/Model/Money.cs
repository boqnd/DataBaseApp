using System.ComponentModel.DataAnnotations;

namespace SQLapp.Data.Model
{
    public class Money
    {
        [Key]
        public string MoneyKey { get; set; }

        [Required]
        public double Money_Amount { get; set; }
    }
}