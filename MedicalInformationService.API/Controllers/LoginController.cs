using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInformationService.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public LoginController(IConfiguration Configuration, ILogger<LoginController> logger)
        {
            _configuration = Configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (IsValidUserNameAndPassword(userName, password))
            {
                return new ObjectResult(new { Token = GenerateToken(userName) });
            }
            return Unauthorized();
        }

        private bool IsValidUserNameAndPassword(string userName, string password)
        {
            //Bu kısımda database'e gidip bu kullanıcı adı ve şifre varmı diye kontrol edilebilir yada bir business işletilebilir.
            
            var returnValue = (userName == "Dancho" && password == "123") ?  true : false;
            return returnValue;
        }

        //Token oluşturmak için kullandığımız method.
        private string GenerateToken(string userName)
        {
            var parameters = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userName)
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((string)Convert.ChangeType(_configuration["JwtTokenConfig:IssuerSigningKey"], typeof(string)))); // Startupda yazdığımız olması gerek.
            var tokenLifeTime = (double)Convert.ChangeType(_configuration["JwtTokenConfig:TokenLifeTime"], typeof(double));

            var token = new JwtSecurityToken(
                issuer: (string)Convert.ChangeType(_configuration["JwtTokenConfig:ValidIssuer"], typeof(string)),
                audience: (string)Convert.ChangeType(_configuration["JwtTokenConfig:ValidAudience"], typeof(string)),
                claims: parameters,
                notBefore: DateTime.Now.AddHours(3),
                expires: DateTime.Now.AddHours(tokenLifeTime), //Jwt Zamanı Utc olarak ayarlıyor. 
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
