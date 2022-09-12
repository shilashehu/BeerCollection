using BeerCollection.Data.Configurations;
using BeerCollection.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeerCollection.Data
{
    public class BeerCollectionContext : DbContext
    {
        public BeerCollectionContext(DbContextOptions<BeerCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Beer> Beer { get; set; }
        public DbSet<BeerRating> BeerRating { get; set; }
        public DbSet<BeerType> BeerType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BeerCollectionContext).Assembly);

            //Seed Data
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 1,
                    Name = "Ale",
                    Description = "Oldest style of beer."
                },
                new BeerType
                {
                    Id = 2,
                    Name = "Lager",
                    Description = "A newer style of beer."
                }
            ); ;
        }
    }
}
