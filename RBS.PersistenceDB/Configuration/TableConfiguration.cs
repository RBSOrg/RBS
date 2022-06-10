using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.PersistenceDB.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables);
        }
    }
}
