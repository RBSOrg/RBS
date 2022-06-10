using RBS.Domain.Entities;

namespace RBS.Data.Abstractions
{
    public interface IUserTokenRepository
    {
        Task AddOrUpdate(string userName, string tokenString, DateTime expireAt);
        Task<UserToken?> GetByRefreshToken(string refreshToken);
        Task DeleteByUserName(string userName);
    }
}
