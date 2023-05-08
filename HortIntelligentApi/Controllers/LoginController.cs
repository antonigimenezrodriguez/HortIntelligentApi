using HortIntelligentApi.Application.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<RespostaAutenticacio>> Registrar(CredencialsUsuari credencialsUsuari)
        {
            var usuari = new IdentityUser() { UserName = credencialsUsuari.Usuari };
            var resultat = await userManager.CreateAsync(usuari, credencialsUsuari.Contrasenya);

            if (resultat.Succeeded)
            {
                return await ConstruirToken(credencialsUsuari);
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
                return await ConstruirToken(credencialsUsuari);
            else
                return BadRequest("Login incorrecte");
        }

        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespostaAutenticacio>> Renovar()
        {
            var usuariClaim = HttpContext.User.Claims.Where(claim => claim.Type == "usuari").FirstOrDefault();
            var usuari = usuariClaim.Value;
            var credencialsUsuari = new CredencialsUsuari()
            {
                Usuari = usuari
            };
            return await ConstruirToken(credencialsUsuari);
        }


        private async Task<ActionResult<RespostaAutenticacio>> ConstruirToken(CredencialsUsuari credencials)
        {
            var claims = new List<Claim>()
            {
                new Claim("usuari", credencials.Usuari)
            };

            var usuari = await userManager.Users.Where(w => w.UserName == credencials.Usuari).FirstOrDefaultAsync();
            var claimsDB = await userManager.GetClaimsAsync(usuari);
            claims.AddRange(claimsDB);

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

        [HttpPost("FerAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> FerAdmin(EditarAdminDto editarAdminDto)
        {
            var usuari = await userManager.Users.Where(w => w.UserName == editarAdminDto.Usuari).FirstOrDefaultAsync();
            if (usuari == null)
            {
                return BadRequest($"No existeix l'usuari: {editarAdminDto.Usuari}");
            }
            await userManager.AddClaimAsync(usuari, new Claim("esAdmin", "true"));
            return NoContent();
        }

        [HttpPost("TreureAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> TreureAdmin(EditarAdminDto editarAdminDto)
        {
            var usuari = await userManager.Users.Where(w => w.UserName == editarAdminDto.Usuari).FirstOrDefaultAsync();
            if (usuari == null)
            {
                return BadRequest($"No existeix l'usuari: {editarAdminDto.Usuari}");
            }
            await userManager.RemoveClaimAsync(usuari, new Claim("esAdmin", "true"));
            return NoContent();
        }


    }
}
