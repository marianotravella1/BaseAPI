using Application.Service.Interfaces;
using Application.Service.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public AuthController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
        {
            User? user = _userService.AuthUser(credentialsDto);

            if (user == null)
            {
                return Unauthorized();
            }

            SymmetricSecurityKey securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]!));
            SigningCredentials credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            List<Claim> claimsForToken = new List<Claim>()
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("given_name", user.UserName)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddMinutes(int.Parse(_config["Authentication:MinToExpireJWT"]!)),
              credentials);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken) });

        }
    }
}
