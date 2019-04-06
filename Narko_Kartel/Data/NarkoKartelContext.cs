using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using SQLapp.Data.Model;

namespace SQLapp.Data
{
    public class NarkoKartelContext : DbContext
    {

        public NarkoKartelContext()
        {
          
        }

        public NarkoKartelContext(DbContextOptions options):base(options)
        {
            
        }
        
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration c = new Configuration();
            
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(c.builder.ConnectionString);

            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}