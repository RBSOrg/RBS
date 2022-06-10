using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.PersistenceDB.Configuration
{
    public class RestaurantTypeConfiguration : IEntityTypeConfiguration<RestaurantType>
    {
        public void Configure(EntityTypeBuilder<RestaurantType> builder)
        {
            builder.HasKey(x => new { x.RestaurantId, x.TypeId });

            builder.HasOne<Domain.Entities.Restaurant>(r => r.Restaurant)
                    .WithMany(rt => rt.RestaurantTypes).OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(r => r.RestaurantId);

            builder.HasOne<Domain.Entities.Type>(t => t.Type)
                    .WithMany(rt => rt.RestaurantTypes).OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(t => t.TypeId);
        }
    }
}
