using Identity.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost(Name = "authenticate")]
        public IActionResult Authenticate([FromBody]User user)
        {
            try
            {

                IActionResult response = Unauthorized();
                if (user != null)
                {
                    if (user.UserName.Equals("asfand@gmail.com") && user.Password.Equals("test123"))
                    {
                        var issuer = _configuration["Jwt:Issuer"];
                        var audience = _configuration["Jwt:Audience"];
                        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                        var signingCredentials = new SigningCredentials(
                                                new SymmetricSecurityKey(key),
                                                SecurityAlgorithms.HmacSha512Signature);
                        var subject = new ClaimsIdentity(new[]{
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, user.UserName),});
                        var expires = DateTime.UtcNow.AddMinutes(10);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = subject,
                            Expires = DateTime.UtcNow.AddMinutes(10),
                            Issuer = issuer,
                            Audience = audience,
                            SigningCredentials = signingCredentials
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var jwtToken = tokenHandler.WriteToken(token);
                        return Ok(jwtToken);
                    }

                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}