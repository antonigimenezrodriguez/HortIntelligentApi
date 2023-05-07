using HortIntelligentApi.Application.Dtos;
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
        public async Task<IList<SensorDto>> Get()
        {
            return await SensorDomini.GetAll();
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
        public async Task<SensorDto> Get(int id)
        {
            return await SensorDomini.Get(id);
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
        public async Task<bool> Delete(int id)
        {
            return await SensorDomini.Delete(id);
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
        public async Task<SensorDto> Post([FromBody] SensorDto sensorDto)
        {
            return await SensorDomini.Post(sensorDto);
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
        public async Task<SensorDto> Put([FromBody] SensorDto sensorDto)
        {
            return await SensorDomini.Put(sensorDto);
        }
    }
}
