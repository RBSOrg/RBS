using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RBS.PersistenceDB.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Domain.Restaurant>
    {
        public void Configure(EntityTypeBuilder<Domain.Restaurant> builder)
        {
            builder.HasOne(r => r.Address)
                .WithOne(a => a.Restaurant)
                .HasForeignKey<Domain.Address>(b => b.Id);

            builder.HasMany(r => r.Imgs)
                .WithOne(i => i.Restaurant);

            builder.HasMany(m => m.Menus)
                .WithOne(i => i.Restaurant);

            builder.HasMany(t => t.Tables)
                .WithOne(i => i.Restaurant);
        }
    }
}
