using BeerCollection.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerCollection.Data.Configurations
{
    internal class BeerTypeEntityConfiguration : IEntityTypeConfiguration<BeerType>
    {
        public void Configure(EntityTypeBuilder<BeerType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);

        }
    }
}
