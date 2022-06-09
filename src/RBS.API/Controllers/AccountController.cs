using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBS.Api.Models;
using RBS.Application.Abstractions;
using System.Security.Claims;

namespace RBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public AccountController(IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<ActionResult> Login([FromBody] LogInRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _userService.IsValidUserCredentials(request.UserName, request.Password))
                return Unauthorized("UserName or Password is not correct.");

            List<string> roles = await _userService.GetUserRoles(request.UserName);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.UserName),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtResult = await _jwtAuthManager.GenerateTokens(request.UserName, claims.ToArray(), DateTime.Now);

            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Roles = roles,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] SignUpRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = await _userService.RegisterAccount(new Application.Models.UserModel()
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            });

            return Ok(userId);
        }
    }
}
