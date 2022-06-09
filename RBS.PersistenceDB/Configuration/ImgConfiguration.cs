using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RBS.Restaurant.PersistenceDB.Configuration
{
    public class ImgConfiguration : IEntityTypeConfiguration<Domain.Img>
    {
        public void Configure(EntityTypeBuilder<Domain.Img> builder)
        {
            builder.HasOne(i => i.Restaurant)
                .WithMany(r => r.Imgs);

            builder.Property(i => i.OrderPriority).HasDefaultValue(0);
        }
    }
}
