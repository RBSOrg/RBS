using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RBS.PersistenceDB.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Domain.Menu>
    {
        public void Configure(EntityTypeBuilder<Domain.Menu> builder)
        {
            builder.HasOne(m => m.Restaurant)
                .WithMany(r => r.Menus);

            //builder.HasMany(m => m.Products)
            //    .WithOne(p => p.Menu);
        }
    }
}
