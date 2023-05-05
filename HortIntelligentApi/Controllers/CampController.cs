using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampController : ControllerBase
    {
        public ICampDomini CampDomini { get; set; }

        public CampController(ICampDomini campDomini)
        {
            CampDomini = campDomini;
        }

        [HttpGet]
        public async Task<IList<CampDto>> Get()
        {
            return await CampDomini.GetAll();
        }

        [HttpGet("id")]
        public async Task<CampDto> Get(int id)
        {
            return await CampDomini.Get(id);
        }

        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            return await CampDomini.Delete(id);
        }

        [HttpPost]
        public async Task<CampDto> Post([FromBody] CampDto campDto)
        {
            return await CampDomini.Post(campDto);
        }

        [HttpPut()]
        public async Task<CampDto> Put([FromBody] CampDto campDto)
        {
            return await CampDomini.Put(campDto);
        }
    }
}
