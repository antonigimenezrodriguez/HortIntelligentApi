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
        public async Task<IList<MedicioDto>> Get()
        {
            return await MedicioDomini.GetAll();
        }

        /// <summary>
        /// Obtenir una medició segons el seu ID.
        /// </summary>
        /// <param name="id">ID de la medició</param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<MedicioDto> Get(int id)
        {
            return await MedicioDomini.Get(id);
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el camp.
        /// </summary>
        /// <param name="campId">ID del camp</param>
        /// <returns></returns>
        [HttpGet("GetByCampId/campId")]
        public async Task<IList<MedicioDto>> GetByCampId(int campId)
        {
            return await MedicioDomini.GetByCampId(campId);
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el vegetal.
        /// </summary>
        /// <param name="vegetalId">ID del vegetal</param>
        /// <returns></returns>
        [HttpGet("GetByVegetalId/vegetalId")]
        public async Task<IList<MedicioDto>> GetByVegetalId(int vegetalId)
        {
            return await MedicioDomini.GetByVegetalId(vegetalId);
        }

        /// <summary>
        /// Obtenir el llistat de medicions segons el sensor.
        /// </summary>
        /// <param name="sensorId">ID del sensor</param>
        /// <returns></returns>
        [HttpGet("GetBySensorId/sensorId")]
        public async Task<IList<MedicioDto>> GetBySensorId(int sensorId)
        {
            return await MedicioDomini.GetBySensorId(sensorId);
        }

        /// <summary>
        /// Borrar una medició.
        /// </summary>
        /// <param name="id">ID de la medició a borrar</param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            return await MedicioDomini.Delete(id);
        }

        /// <summary>
        /// Afegir una nova medició.
        /// </summary>
        /// <param name="medicioDto">Medició a afegir</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MedicioDto> Post([FromBody] MedicioDto medicioDto)
        {
            return await MedicioDomini.Post(medicioDto);
        }
    }
}
