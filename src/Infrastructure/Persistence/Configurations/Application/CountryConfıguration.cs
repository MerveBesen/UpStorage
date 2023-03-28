using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application;

public class CountryConfıguration:IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Relationships
        builder.HasMany<City>(x => x.Cities)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);

    }
}