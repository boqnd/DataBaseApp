using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SQLapp.Data.Model
{
    public class Dealer
    {
        public Dealer()
        {
            
        }
        public Dealer(string firstName, string lastName, string nickname, string city)
        {
            this.First_Name = firstName;
            this.Last_Name = lastName;
            this.Nickname = nickname;
            this.CityFrom = city;
            this.Money_Brought_This_Month = 10;
        }
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string First_Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Last_Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(20)]
        public string CityFrom { get; set; }

        [Required]
        public double Money_Brought_This_Month { get; set; }
    }
}