using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using EmployeeManagmentSysytemAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagmentSysytemAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        public AuthenticateController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Authenticate(EmployeesManagmentSystemWeb.API.Models.Login login)
        {
            if (login.UserName == "test@desaisiv.com" && login.Password == "P@ssw0rd")
            {
                var loginResponse = new LoginResponseModel();
                loginResponse.code = 200;
                loginResponse.Message = "Token";
                var issuer = Configuration.GetSection("Jwt")["Issuer"];
                var audience = Configuration.GetSection("Jwt")["Audience"];
                var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt")["Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, login.Password),
                new Claim(JwtRegisteredClaimNames.Email, login.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                loginResponse.Message = stringToken; 
                return Ok(loginResponse);
            }
            else
            {
                var loginResponse = new LoginResponseModel();
                loginResponse.code = 400;
                loginResponse.Message = "user not found";
                return Ok(loginResponse);
            }
           
        }



        [Route("[action]")]
        [HttpGet]
        public void Logout()
        {
            // Remove Token;
            HttpContext.Session.SetString("Token", "");
        }
    }
}
