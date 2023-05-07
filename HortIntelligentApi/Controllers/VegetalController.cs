using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de vegetals
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VegetalController : ControllerBase
    {
        public IVegetalDomini VegetalDomini { get; set; }

        public VegetalController(IVegetalDomini vegetalDomini)
        {
            VegetalDomini = vegetalDomini;
        }

        /// <summary>
        /// Obtenir el llistat de vegetals.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IList<VegetalDto>> Get()
        {
            return await VegetalDomini.GetAll();
        }

        /// <summary>
        /// Obtenir un vegetal segons el seu ID.
        /// </summary>
        /// <param name="id">ID del vegetal</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<VegetalDto> Get(int id)
        {
            return await VegetalDomini.Get(id);
        }

        /// <summary>
        /// Borrar un vegetal.
        /// </summary>
        /// <param name="id">ID del vegetal a borrar</param>
        /// <returns></returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<bool> Delete(int id)
        {
            return await VegetalDomini.Delete(id);
        }

        /// <summary>
        /// Afegir un nou vegetal.
        /// </summary>
        /// <param name="vegetal">Vegetal a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<VegetalDto> Post([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Post(vegetal);
        }

        /// <summary>
        /// Modificar un vegetal.
        /// </summary>
        /// <param name="vegetal">Vegetal a modificar</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<VegetalDto> Put([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Put(vegetal);
        }
    }
}
