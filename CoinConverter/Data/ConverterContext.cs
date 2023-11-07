using CoinConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinConverter.Data
{
    public class ConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Currency> Currency { get; set; }

        public ConverterContext(DbContextOptions<ConverterContext>options ) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne<Subscription>(u => u.subscription);
          
        }
    }
}
