using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SQLapp.Data.Model
{
    public class Buyer
    {
     
        public Buyer()
        {
            
        }
        public Buyer(string nickname, int dealerId)
        {
            this.Nickname = nickname;
            this.DealerId = dealerId;
        }
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Nickname { get; set; }
        
        [Required]
        public Dealer Dealer { get; set; }
        
        [Required]
        public int DealerId { get; set; }
    }
}