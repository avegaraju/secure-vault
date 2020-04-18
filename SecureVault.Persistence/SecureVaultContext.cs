using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecureVault.Persistence.Models;

namespace SecureVault.Persistence
{
    public class SecureVaultContext: DbContext
    {
        public SecureVaultContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        private DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardType>()
                .HasData(new List<CardType>
                {
                    new CardType
                    {
                        CardTypeId = 1,
                        Name = "MasterCard",
                    },
                    new CardType
                    {
                        CardTypeId = 2,
                        Name = "Maestro",
                    },
                    new CardType
                    {
                        CardTypeId = 3,
                        Name = "American Express"
                    }
                });
        }
    }
}
