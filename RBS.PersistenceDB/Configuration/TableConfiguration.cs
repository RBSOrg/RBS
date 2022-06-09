using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RBS.PersistenceDB.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Domain.Table>
    {
        public void Configure(EntityTypeBuilder<Domain.Table> builder)
        {
            builder.HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables);
        }
    }
}
