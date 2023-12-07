using CoinConverter.Models.DTO;
using CoinConverter.Services.Implementations;
using CoinConverter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoinConverter.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserServices _userService;

        public AuthenticationController(IConfiguration config, IUserServices userService)
        {
            _config = config; 
            this._userService = userService;

        }

        [HttpPost("authenticate")] 
        public IActionResult Autenticar(AuthRequestDto authenticationRequestBody) 
        {
            //Paso 1: Validamos las credenciales
            var user = _userService.ValidateUser(authenticationRequestBody);
            Console.WriteLine("Llego aca");
            if (user is null) 
                return Unauthorized();
            Console.WriteLine("Aca tmb");
            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:Key"])); 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString())); 
            claimsForToken.Add(new Claim("username", user.Username)); 
            claimsForToken.Add(new Claim("Email", user.Email)); 

            var jwtSecurityToken = new JwtSecurityToken( 
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() 
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }

}

