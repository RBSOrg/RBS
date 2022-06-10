using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.PersistenceDB.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasOne(m => m.Restaurant)
                .WithMany(r => r.Menus);

            //builder.HasMany(m => m.Products)
            //    .WithOne(p => p.Menu);
        }
    }
}
