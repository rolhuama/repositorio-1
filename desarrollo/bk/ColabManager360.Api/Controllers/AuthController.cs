using ColabManager360.Aplication.Services.Security;
using ColabManager360.Domain.Configurations;
using ColabManager360.Domain.Entities.Auth.Requests;
using ColabManager360.Domain.Entities.Auth.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly JwtConfig _JwtConfig;

        public AuthController(ISecurityService securityService, IOptions<JwtConfig> jwtConfig)
        {
            _securityService = securityService;
            _JwtConfig = jwtConfig.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserRequest request)
        {
            var response = await _securityService.Login(request);

            if (response != null)
            {
                JwtGenerator(response);
                return Ok(response);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LoginGoogle")]
        public async Task<IActionResult> LoginGoogle(GoogleCredentialsRequest request)
        {
            var response = await _securityService.LoginGoogle(request);

            if (response != null)
            {
                JwtGenerator(response);
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {

            //var token = token; // Asumiendo que JwtGenerator devuelve el token
            // Leer el token desde la cookie
            var token = HttpContext.Request.Cookies[_JwtConfig.CookieName];
            var tokenHandler = new JwtSecurityTokenHandler();

            // Decodificar el token
            if (tokenHandler.CanReadToken(token))
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Acceder a las claims (datos) del token
                var userName = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "unique_name")?.Value;
                var userRole = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;
                var expirationDate = jwtToken.ValidTo;

                if (expirationDate < DateTime.UtcNow)
                {
                    return Unauthorized();
                }


                var response = new UserResponse { Email = userName, Role = userRole };

                JwtGenerator(response);
                return Ok(response);
            }

            return Unauthorized();
        }

        private void JwtGenerator(UserResponse user)
        {

            if (user.Role != "")
            {
                user.TokenCreated = DateTime.UtcNow;
                user.TokenExpires = user.TokenCreated.AddMinutes((double)_JwtConfig.Expires);

                var issuer = _JwtConfig.Issuer;
                var audience = _JwtConfig.Audience;
                var key = Encoding.ASCII.GetBytes(_JwtConfig.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = user.TokenExpires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                var stringToken = tokenHandler.WriteToken(token);

                HttpContext.Response.Cookies.Delete("ColabManager360");

                HttpContext.Response.Cookies.Append(_JwtConfig.CookieName, stringToken, new CookieOptions
                {
                    Expires = user.TokenExpires,
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None
                });
            }

        }

    }
}
