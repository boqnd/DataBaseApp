using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SQLapp.Data.Model
{
    public class Drug
    {
        public Drug()
        {
            
        }
        public Drug(string firstName, double sellPrice, double acquirePrice)
        {
            this.Name = firstName;
            this.Sell_Price = sellPrice;
            this.Acquire_Price = acquirePrice;
            this.Quantity = 2;
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public double Sell_Price { get; set; }

        [Required]
        public double Acquire_Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        
    }
}