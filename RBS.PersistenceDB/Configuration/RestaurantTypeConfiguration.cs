using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RBS.PersistenceDB.Configuration
{
    public class RestaurantTypeConfiguration : IEntityTypeConfiguration<Domain.RestaurantType>
    {
        public void Configure(EntityTypeBuilder<Domain.RestaurantType> builder)
        {
            builder.HasKey(x => new { x.RestaurantId, x.TypeId });

            builder.HasOne<Domain.Restaurant>(r => r.Restaurant)
                    .WithMany(rt => rt.RestaurantTypes).OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(r => r.RestaurantId);

            builder.HasOne<Domain.Type>(t => t.Type)
                    .WithMany(rt => rt.RestaurantTypes).OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(t => t.TypeId);
        }
    }
}
