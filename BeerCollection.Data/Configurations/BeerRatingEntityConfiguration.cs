using BeerCollection.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerCollection.Data.Configurations
{
    internal class BeerRatingEntityConfiguration : IEntityTypeConfiguration<BeerRating>
    {
        public void Configure(EntityTypeBuilder<BeerRating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Score).IsRequired();
            builder.Property(x => x.BeerId).IsRequired();
        }
    }
}
