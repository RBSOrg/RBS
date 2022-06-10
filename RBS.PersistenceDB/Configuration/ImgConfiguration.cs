using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.Restaurant.PersistenceDB.Configuration
{
    public class ImgConfiguration : IEntityTypeConfiguration<Img>
    {
        public void Configure(EntityTypeBuilder<Img> builder)
        {
            builder.HasOne(i => i.Restaurant)
                .WithMany(r => r.Imgs);

            builder.Property(i => i.OrderPriority).HasDefaultValue(0);
        }
    }
}
