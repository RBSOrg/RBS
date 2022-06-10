using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.PersistenceDB.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Domain.Entities.Restaurant>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Restaurant> builder)
        {
            builder.HasOne(r => r.Address)
                .WithOne(a => a.Restaurant)
                .HasForeignKey<Address>(b => b.Id);

            builder.HasMany(r => r.Imgs)
                .WithOne(i => i.Restaurant);

            builder.HasMany(m => m.Menus)
                .WithOne(i => i.Restaurant);

            builder.HasMany(t => t.Tables)
                .WithOne(i => i.Restaurant);
        }
    }
}
