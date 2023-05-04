using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    /// <summary>
    /// Controlador de vegetals
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<VegetalDto> Post([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Post(vegetal);
        }

        /// <summary>
        /// Modificar un vegetal.
        /// </summary>
        /// <param name="vegetal">Vegetal a borrar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<VegetalDto> Put([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Put(vegetal);
        }
    }
}
