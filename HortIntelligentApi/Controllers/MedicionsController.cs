using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de Medicions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IList<MedicioDto>>> Get()
        {
            return Ok(await MedicioDomini.GetAll());
        }

        /// <summary>
        /// Obtenir una medició segons el seu ID.
        /// </summary>
        /// <param name="id">ID de la medició</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MedicioDto>> Get(int id)
        {
            var medicio = await MedicioDomini.Get(id);
            if (medicio == null)
                return NotFound($"No s'ha trobat una medició amb ID: {id}");
            else
                return Ok(medicio);
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el camp.
        /// </summary>
        /// <param name="campId">ID del camp</param>
        /// <returns></returns>
        [HttpGet("GetByCampId/campId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            if(!await MedicioDomini.Exists(id))
                return NotFound($"No s'ha trobat una medició amb ID: {id}");
            var result = await MedicioDomini.Delete(id);
            if (result)
                return Ok(id);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, $"Valor no esperat al borrar la medició {id}");
        }

        /// <summary>
        /// Afegir una nova medició.
        /// </summary>
        /// <param name="medicioDto">Medició a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicioDto>> Post([FromBody] MedicioDto medicioDto)
        {
            if (medicioDto == null)
                return BadRequest();
            var existeixCamp = await MedicioDomini.ExisteixCamp(medicioDto.CampId);
            var existeixVegetal = await MedicioDomini.ExisteixVegetal(medicioDto.VegetalId);
            var existeixSensor = await MedicioDomini.ExisteixSensor(medicioDto.SensorId);

            string errorFK = string.Empty;

            if(!existeixCamp || !existeixVegetal || !existeixSensor)
            {
                errorFK = "Les següent FK no existeixen: ";
                if (!existeixCamp)
                    errorFK += $"\r\nCamp amb id: {medicioDto.CampId}";
                if(!existeixVegetal)
                    errorFK += $"\r\nVegetal amb id: {medicioDto.VegetalId}";
                if(!existeixSensor)
                errorFK += $"\r\nSensor amb id: {medicioDto.SensorId}";

                return BadRequest(errorFK);
            }
            return Ok(await MedicioDomini.Post(medicioDto));
        }
    }
}
