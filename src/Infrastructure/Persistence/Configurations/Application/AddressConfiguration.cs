using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration:IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            
            //Name 
            builder.Property(x => x.Name).IsRequired();
            
            //UserId
            builder.Property(x => x.User).IsRequired();
            
            //CountryId
            builder.Property(x => x.CountryId).IsRequired();
            
            //CityId
            builder.Property(x => x.CityId).IsRequired();
            
            //District 
            builder.Property(x => x.District).IsRequired();
            
            //PostCode 
            builder.Property(x => x.PostCode).IsRequired();
            
            //AddressLine1
            builder.Property(x => x.AddressLine1).IsRequired();
            
            //AddressLine2 
            builder.Property(x => x.AddressLine2);

            //AddressType
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.AddressType).HasConversion<int>();

            // CreatedDate
            builder.Property(x => x.CreatedOn).IsRequired();
            
            // CreatedByUserId
            builder.Property(user => user.CreatedByUserId).IsRequired(false);
            
            // ModifiedDate
            builder.Property(user => user.ModifiedOn).IsRequired(false);
            
            // ModifiedByUserId
            builder.Property(user => user.ModifiedByUserId).IsRequired(false);

            
            builder.ToTable("Addresses");
        }
    }
}
