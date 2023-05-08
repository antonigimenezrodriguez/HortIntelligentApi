using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Implementacions;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de sensors
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SensorController : ControllerBase
    {
        public ISensorDomini SensorDomini { get; set; }

        public SensorController(ISensorDomini sensorDomini)
        {
            SensorDomini = sensorDomini;
        }

        /// <summary>
        /// Obtenir el llistat de sensors.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<SensorDto>>> Get()
        {
            var result = await SensorDomini.GetAll();
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
        /// Obtenir un sensor segons el seu ID.
        /// </summary>
        /// <param name="id">ID del sensor</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SensorDto>> Get(int id)
        {
            var result = await SensorDomini.Get(id);
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
        /// Borrar un sensor.
        /// </summary>
        /// <param name="id">ID del sensor</param>
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
            var result = await SensorDomini.Delete(id);
            if (!result.Error)
                return Ok(id);
            else
                return StatusCode(result.StatusCode, result.ToString());
        }

        /// <summary>
        /// Afegir un nou sensor.
        /// </summary>
        /// <param name="sensorDto">Sensor a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<SensorDto>> Post([FromBody] SensorDto sensorDto)
        {
            if (sensorDto == null)
                return BadRequest();
            ResultDto<SensorDto> resultat = await SensorDomini.Post(sensorDto);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }

        /// <summary>
        /// Modificar un sensor.
        /// </summary>
        /// <param name="sensorDto">Sensor a borrar</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<SensorDto>> Put([FromBody] SensorDto sensorDto)
        {
            if (sensorDto == null)
                return BadRequest();
            ResultDto<SensorDto> resultat = await SensorDomini.Put(sensorDto);
            if (resultat.Error)
                return StatusCode(resultat.StatusCode, resultat.ToString());
            else
                return Ok(resultat.Data);
        }
    }
}
