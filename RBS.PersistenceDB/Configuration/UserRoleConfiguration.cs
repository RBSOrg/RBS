using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBS.Domain.Entities;

namespace RBS.PersistenceDB.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne<User>(ur => ur.User)
                    .WithMany(u => u.UserRoles).OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(u => u.UserId);

            builder.HasOne<Role>(ur => ur.Role)
                  .WithMany(r => r.UserRoles).OnDelete(DeleteBehavior.Cascade)
                  .HasForeignKey(r => r.RoleId);
        }
    }
}
