using RBS.Application.Models;
using System.Security.Claims;

namespace RBS.Application.Abstractions
{
    public interface IJwtAuthManager
    {
        Task<JwtAuthResult> GenerateTokens(string userName, Claim[] claims, DateTime now);
    }
}
