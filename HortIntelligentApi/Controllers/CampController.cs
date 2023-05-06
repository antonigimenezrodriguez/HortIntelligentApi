using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de camps
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IList<CampDto>> Get()
        {
            return await CampDomini.GetAll();
        }

        /// <summary>
        /// Obtenir un camp segons el seu ID.
        /// </summary>
        /// <param name="id">ID del camp</param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<CampDto> Get(int id)
        {
            return await CampDomini.Get(id);
        }

        /// <summary>
        /// Borrar un camp.
        /// </summary>
        /// <param name="id">ID del camp</param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            return await CampDomini.Delete(id);
        }

        /// <summary>
        /// Afegir un nou camp.
        /// </summary>
        /// <param name="campDto">Camp a afegir</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CampDto> Post([FromBody] CampDto campDto)
        {
            return await CampDomini.Post(campDto);
        }

        /// <summary>
        /// Modificar un camp.
        /// </summary>
        /// <param name="campDto">Camp a modificar</param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<CampDto> Put([FromBody] CampDto campDto)
        {
            return await CampDomini.Put(campDto);
        }
    }
}
