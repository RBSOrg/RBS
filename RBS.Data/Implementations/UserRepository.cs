using Microsoft.EntityFrameworkCore;
using RBS.Data.Abstractions;
using RBS.Domain;
using RBS.PersistenceDB.Context;

namespace RBS.Data.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(RBSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<int> CreateAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> Exists(string userName)
        {
            return await _dbSet.AnyAsync(us => us.UserName == userName);
        }

        public async Task<User?> GetUserWithRoles(string userName)
        {
            var result = await _dbSet.Include(x => x.UserRoles).ThenInclude(x => x.Role).SingleOrDefaultAsync(us => us.UserName == userName);

            return result;
        }

        public async Task<bool> ValidateUserCredentials(string userName, string hashedPassword)
        {
            return await _dbSet.AnyAsync(us => us.UserName == userName && us.Password == hashedPassword);
        }
    }
}
