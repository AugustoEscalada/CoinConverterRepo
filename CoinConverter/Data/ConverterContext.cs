using CoinConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinConverter.Data
{
    public class ConverterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Currency> Currency { get; set; }

    }
}
