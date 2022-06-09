using Microsoft.EntityFrameworkCore;
using RBS.Domain;

namespace RBS.PersistenceDB.Context
{
    public class RBSDbContext : DbContext
    {

        public RBSDbContext(DbContextOptions<RBSDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Domain.Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<Domain.Type> Types { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RBSDbContext).Assembly);
        }
    }
}
