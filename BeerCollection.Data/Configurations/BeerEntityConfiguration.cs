using BeerCollection.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerCollection.Data.Configurations
{
    internal class BeerEntityConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x => x.BeerTypeId).IsRequired();
            builder.Property(x => x.AvgRating);
        }
    }
}
