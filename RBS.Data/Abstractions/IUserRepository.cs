using RBS.Domain.Entities;

namespace RBS.Data.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> ValidateUserCredentials(string userName, string hashedPassword);
        Task<bool> Exists(string userName);
        Task<int> CreateAsync(User user);
        Task<User?> GetUserWithRoles(string userName);
    }
}
