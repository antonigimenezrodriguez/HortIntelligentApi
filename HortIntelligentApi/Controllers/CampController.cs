using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de camps
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CampController : ControllerBase
    {
        public ICampDomini CampDomini { get; set; }

        public CampController(ICampDomini campDomini)
        {
            CampDomini = campDomini;
        }

        /// <summary>
        /// Obtenir el llistat de camps.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IList<CampDto>>> Get()
        {
            var result = await CampDomini.GetAll();
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
        /// Obtenir un camp segons el seu ID.
        /// </summary>
        /// <param name="id">ID del camp</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampDto>> Get(int id)
        {
            var result = await CampDomini.Get(id);
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
        /// Borrar un camp.
        /// </summary>
        /// <param name="id">ID del camp</param>
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
            var result = await CampDomini.Delete(id);
            if (!result.Error)
                return Ok(id);
            else
                return StatusCode(result.StatusCode, result.ToString());
        }

        /// <summary>
        /// Afegir un nou camp.
        /// </summary>
        /// <param name="campDto">Camp a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<CampDto>> Post([FromBody] CampDto campDto)
        {
            if (campDto == null)
                return BadRequest();
            ResultDto<CampDto> resultat = await CampDomini.Post(campDto);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }

        /// <summary>
        /// Modificar un camp.
        /// </summary>
        /// <param name="campDto">Camp a modificar</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<CampDto>> Put([FromBody] CampDto campDto)
        {
            if (campDto == null)
                return BadRequest();
            ResultDto<CampDto> resultat = await CampDomini.Put(campDto);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }
    }
}
