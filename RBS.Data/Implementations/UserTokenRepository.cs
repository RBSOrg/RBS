using Microsoft.EntityFrameworkCore;
using RBS.Data.Abstractions;
using RBS.Domain.Entities;
using RBS.PersistenceDB.Context;

namespace RBS.Data.Implementations
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<UserToken> _entitie;

        public UserTokenRepository(RBSDbContext context)
        {
            _context = context;
            _entitie = _context.Set<UserToken>();
        }

        public async Task AddOrUpdate(string userName, string tokenString, DateTime expireAt)
        {
            var userToken = await _entitie.SingleOrDefaultAsync(ut => ut.UserName == userName && ut.TokenString == tokenString);
            var userTokenModel = new UserToken()
            {
                UserName = userName,
                TokenString = tokenString,
                ExpireAt = expireAt
            };

            if (userToken == null)
                await _entitie.AddAsync(userTokenModel);
            else
                _entitie.Update(userTokenModel);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteByUserName(string userName)
        {
            var userTokens = await _entitie.Where(ut => ut.UserName == userName)
                                        .ToListAsync();
            if (userTokens.Count > 0)
                _entitie.RemoveRange(userTokens);
        }

        public async Task<UserToken?> GetByRefreshToken(string refreshToken)
        {
            return await _entitie.FirstOrDefaultAsync(ut => ut.TokenString == refreshToken);
        }
    }
}
