using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Implementacions;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de Medicions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicionsController : ControllerBase
    {
        public IMedicioDomini MedicioDomini { get; set; }

        public MedicionsController(IMedicioDomini medicioDomini)
        {
            MedicioDomini = medicioDomini;
        }

        /// <summary>
        /// Obtenir el llistat de medicions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<MedicioDto>>> Get()
        {
            var result = await MedicioDomini.GetAll();
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
        /// Obtenir una medició segons el seu ID.
        /// </summary>
        /// <param name="id">ID de la medició</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MedicioDto>> Get(int id)
        {
            var result = await MedicioDomini.Get(id);
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
        /// Obtenir el llistat de medicions segons el camp.
        /// </summary>
        /// <param name="campId">ID del camp</param>
        /// <returns></returns>
        [HttpGet("GetByCampId/campId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<MedicioDto>>> GetByCampId(int campId)
        {
            var existeixCamp = await MedicioDomini.ExisteixCamp(campId);
            if (!existeixCamp)
                return NotFound($"No existeix un camp amb ID: {campId}");
            return Ok(await MedicioDomini.GetByCampId(campId));
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el vegetal.
        /// </summary>
        /// <param name="vegetalId">ID del vegetal</param>
        /// <returns></returns>
        [HttpGet("GetByVegetalId/vegetalId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<MedicioDto>>> GetByVegetalId(int vegetalId)
        {
            var existeixVegetal = await MedicioDomini.ExisteixVegetal(vegetalId);
            if (!existeixVegetal)
                return NotFound($"No existeix un vegetal amb ID: {vegetalId}");
            return Ok(await MedicioDomini.GetByVegetalId(vegetalId));
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el sensor.
        /// </summary>
        /// <param name="sensorId">ID del sensor</param>
        /// <returns></returns>
        [HttpGet("GetBySensorId/sensorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<MedicioDto>>> GetBySensorId(int sensorId)
        {
            var existeixMedicio = await MedicioDomini.ExisteixSensor(sensorId);
            if (!existeixMedicio)
                return NotFound($"No existeix un sensor amb ID: {sensorId}");
            return Ok(await MedicioDomini.GetBySensorId(sensorId));
        }

        /// <summary>
        /// Borrar una medició.
        /// </summary>
        /// <param name="id">ID de la medició a borrar</param>
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
            var result = await MedicioDomini.Delete(id);
            if (!result.Error)
                return Ok(id);
            else
                return StatusCode(result.StatusCode, result.ToString());
        }

        /// <summary>
        /// Afegir una nova medició.
        /// </summary>
        /// <param name="medicioDto">Medició a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MedicioDto>> Post([FromBody] MedicioDto medicioDto)
        {
            if (medicioDto == null)
                return BadRequest();
            ResultDto<MedicioDto> resultat = await MedicioDomini.Post(medicioDto);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }
    }
}
