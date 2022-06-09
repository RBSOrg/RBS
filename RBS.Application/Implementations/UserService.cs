using RBS.Application.Abstractions;
using RBS.Application.Exceptions;
using RBS.Application.Models;
using RBS.Data.Abstractions;
using RBS.Domain;
using System.Security.Cryptography;
using System.Text;

namespace RBS.Application.Implementations
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> IsValidUserCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return false;

            return await _userRepository.ValidateUserCredentials(userName, GenerateMD5Hash(password));
        }

        public async Task<List<string>> GetUserRoles(string userName)
        {
            User? user = await _userRepository.GetUserWithRoles(userName);

            if (user == null)
                throw new UserNotFoundException(400, $"{userName} Not found");

            return user.UserRoles.Select(role => role.Role.RoleName).ToList();
        }

        public async Task<int> RegisterAccount(UserModel user)
        {
            if (await _userRepository.Exists(user.UserName))
                throw new UserAlreadyExistException(400, $"{user.UserName} already exist");

            var hashedPassword = GenerateMD5Hash(user.Password);
            user.Password = hashedPassword;

            User userDomain = new User()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };

            return await _userRepository.CreateAsync(userDomain);
        }

        private static string GenerateMD5Hash(string input)
        {
            using MD5 mD5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = mD5.ComputeHash(bytes);

            StringBuilder sb = new();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
