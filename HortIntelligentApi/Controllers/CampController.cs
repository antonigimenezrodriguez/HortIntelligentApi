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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<CampDto>>> Get()
        {
            return Ok(await CampDomini.GetAll());
        }


        /// <summary>
        /// Obtenir un camp segons el seu ID.
        /// </summary>
        /// <param name="id">ID del camp</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CampDto>> Get(int id)
        {
            var camp = await CampDomini.Get(id);
            if (camp == null)
                return NotFound($"No s'ha trobat un camp amb ID: {id}");
            else
                return Ok(camp);
        }

        /// <summary>
        /// Borrar un camp.
        /// </summary>
        /// <param name="id">ID del camp</param>
        /// <returns></returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            if (!await CampDomini.Exists(id))
                return NotFound($"No s'ha trobat un camp amb ID: {id}");
            var result = await CampDomini.Delete(id);
            if (result)
                return Ok(id);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, $"Valor no esperat al borrar el camp {id}");
        }

        /// <summary>
        /// Afegir un nou camp.
        /// </summary>
        /// <param name="campDto">Camp a afegir</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CampDto>> Post([FromBody] CampDto campDto)
        {
            if (campDto == null)
                return BadRequest();
            return Ok(await CampDomini.Post(campDto));
        }

        /// <summary>
        /// Modificar un camp.
        /// </summary>
        /// <param name="campDto">Camp a modificar</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CampDto>> Put([FromBody] CampDto campDto)
        {
            if (campDto == null)
                return BadRequest();
            if (!await CampDomini.Exists(campDto.Id))
                return NotFound($"No s'ha trobat un camp amb ID: {campDto.Id}");
            return Ok(await CampDomini.Put(campDto));
        }
    }
}
