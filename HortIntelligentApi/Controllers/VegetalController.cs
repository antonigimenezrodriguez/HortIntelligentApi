using AutoMapper;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Implementacions;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<VegetalDto>>> Get()
        {
            var result = await VegetalDomini.GetAll();
            if (result.Error)
            {
                return StatusCode(result.StatusCode, result.ToString());
            }
            else
            {
                return Ok(result.Data);
            }
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<VegetalDto>> Get(int id)
        {
            var result = await VegetalDomini.Get(id);
            if (result.Error)
            {
                return StatusCode(result.StatusCode, result.ToString());
            }
            else
            {
                return Ok(result.Data);
            }
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
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await VegetalDomini.Delete(id);
            if (!result.Error)
                return Ok(id);
            else
                return StatusCode(result.StatusCode, result.ToString());
        }

        /// <summary>
        /// Afegir un nou vegetal.
        /// </summary>
        /// <param name="vegetal">Vegetal a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<VegetalDto>> Post([FromBody] VegetalDto vegetal)
        {
            if (vegetal == null)
                return BadRequest();
            ResultDto<VegetalDto> resultat = await VegetalDomini.Post(vegetal);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<VegetalDto>> Put([FromBody] VegetalDto vegetal)
        {
            if (vegetal == null)
                return BadRequest();
            ResultDto<VegetalDto> resultat = await VegetalDomini.Put(vegetal);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }
    }
}
