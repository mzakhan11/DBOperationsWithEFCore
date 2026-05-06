using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCoreApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyType>().HasData(
                new CurrencyType(){Id = 1, Title = "PKR", Description = "Pakistani PKR"},
                new CurrencyType(){Id = 2, Title = "Dollar", Description = "Dollar"},
                new CurrencyType(){Id = 3, Title = "Euro", Description = "Euro"},
                new CurrencyType(){Id = 4, Title = "Dinar", Description = "Dinar"}
            );
            modelBuilder.Entity<Language>().HasData(
                new Language(){Id = 1, Title = "Urdu", Description = "Urdu"},
                new Language(){Id = 2, Title = "Sindhi", Description = "Sindhi"},
                new Language(){Id = 3, Title = "Punjabi", Description = "Punjabi"},
                new Language(){Id = 4, Title = "Pashto", Description = "Pashto"}
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<CurrencyType> Currencies { get; set; }
    }
}
