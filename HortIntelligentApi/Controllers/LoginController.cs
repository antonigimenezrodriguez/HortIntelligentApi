using HortIntelligentApi.Application.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HortIntelligentApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<RespostaAutenticacio>> Registrar(CredencialsUsuari credencialsUsuari)
        {
            var usuari = new IdentityUser() { UserName = credencialsUsuari.Usuari };
            var resultat = await userManager.CreateAsync(usuari, credencialsUsuari.Contrasenya);

            if (resultat.Succeeded)
            {
                return ConstruirToken(credencialsUsuari);
            }
            else
            {
                return BadRequest(resultat.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<RespostaAutenticacio>> Login(CredencialsUsuari credencialsUsuari)
        {
            var resultat = await signInManager.PasswordSignInAsync(credencialsUsuari.Usuari, credencialsUsuari.Contrasenya, isPersistent: false, lockoutOnFailure: false);
            if (resultat.Succeeded)
                return ConstruirToken(credencialsUsuari);
            else
                return BadRequest("Login incorrecte");
        }

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<RespostaAutenticacio> Renovar()
        {
            var usuariClaim = HttpContext.User.Claims.Where(claim => claim.Type == "usuari").FirstOrDefault();
            var usuari = usuariClaim.Value;
            var credencialsUsuari = new CredencialsUsuari()
            {
                Usuari = usuari
            };
            return ConstruirToken(credencialsUsuari);
        }


        private RespostaAutenticacio ConstruirToken(CredencialsUsuari credencials)
        {
            var claims = new List<Claim>()
            {
                new Claim("usuari", credencials.Usuari)
            };

            var clau = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ClauJWT"]));
            var creds = new SigningCredentials(clau, SecurityAlgorithms.HmacSha256);

            var expiracio = DateTime.UtcNow.AddMinutes(30);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracio, signingCredentials: creds);
            return new RespostaAutenticacio()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracio = expiracio
            };
        }

    }
}
