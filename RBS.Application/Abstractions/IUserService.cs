using RBS.Application.Models;

namespace RBS.Application.Abstractions
{
    public interface IUserService
    {
        Task<bool> IsValidUserCredentials(string userName, string password);
        Task<List<string>> GetUserRoles(string userName);
        Task<int> RegisterAccount(UserModel user);
    }
}
