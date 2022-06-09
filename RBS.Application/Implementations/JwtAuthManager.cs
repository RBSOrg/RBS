using Microsoft.IdentityModel.Tokens;
using RBS.Application.Abstractions;
using RBS.Application.Models;
using RBS.Data.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RBS.Application.Implementations
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly byte[] _secret;

        public JwtAuthManager(JwtTokenConfig jwtTokenConfig, IUserTokenRepository userTokenRepository)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
            _userTokenRepository = userTokenRepository;
        }

        public async Task<JwtAuthResult> GenerateTokens(string userName, Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                           _jwtTokenConfig.Issuer,
                           shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                           claims,
                           expires: now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256));


            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = new RefreshToken
            {
                UserName = userName,
                TokenString = GenerateRefreshTokenString(),
                ExpireAt = now.AddMinutes(_jwtTokenConfig.RefreshTokenExpiration)
            };

            await _userTokenRepository.AddOrUpdate(refreshToken.UserName, refreshToken.TokenString, refreshToken.ExpireAt);

            return new JwtAuthResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<JwtAuthResult> Refresh(string refreshToken, string accessToken, DateTime now)
        {
            var (principal, jwtToken) = DecodeJwtToken(accessToken);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                throw new SecurityTokenException("Invalid token");

            var userName = principal.Identity?.Name;
            var existingRefreshTokenDomain = await _userTokenRepository.GetByRefreshToken(refreshToken);

            var existingRefreshToken = new RefreshToken()
            {
                UserName = existingRefreshTokenDomain.UserName,
                TokenString = existingRefreshTokenDomain.TokenString,
                ExpireAt = existingRefreshTokenDomain.ExpireAt
            };

            if (existingRefreshToken == null || existingRefreshToken.UserName != userName || existingRefreshToken.ExpireAt < now)
                throw new SecurityTokenException("Invalid token");

            return await GenerateTokens(userName, principal.Claims.ToArray(), now); // need to recover the original claims
        }

        public async void RemoveRefreshTokenByUserName(string userName)
        {
            await _userTokenRepository.DeleteByUserName(userName);
        }

        private (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _jwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_secret),
                        ValidAudience = _jwtTokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    },
                    out var validatedToken);

            return (principal, validatedToken as JwtSecurityToken);
        }


        private static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
