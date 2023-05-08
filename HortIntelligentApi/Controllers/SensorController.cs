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
        public async Task<ActionResult<IList<SensorDto>>> Get()
        {
            return Ok(await SensorDomini.GetAll());
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
        public async Task<ActionResult<SensorDto>> Get(int id)
        {
            var sensor = await SensorDomini.Get(id);
            if (sensor == null)
                return NotFound($"No s'ha trobat un sensor amb ID: {id}");
            else
                return Ok(sensor);
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
            if (!await SensorDomini.Exists(id))
                return NotFound($"No s'ha trobat un sensor amb ID: {id}");
            var result = await SensorDomini.Delete(id);
            if (result)
                return Ok(id);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, $"Valor no esperat al borrar el sensor {id}");
        }

        /// <summary>
        /// Afegir un nou sensor.
        /// </summary>
        /// <param name="sensorDto">Sensor a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<SensorDto>> Post([FromBody] SensorDto sensorDto)
        {
            if (sensorDto == null)
                return BadRequest();
            return Ok(await SensorDomini.Post(sensorDto));
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult<SensorDto>> Put([FromBody] SensorDto sensorDto)
        {
            if (sensorDto == null)
                return BadRequest();
            if (!await SensorDomini.Exists(sensorDto.Id))
                return NotFound($"No s'ha trobat un sensor amb ID: {sensorDto.Id}");
            return await SensorDomini.Put(sensorDto);
        }
    }
}
