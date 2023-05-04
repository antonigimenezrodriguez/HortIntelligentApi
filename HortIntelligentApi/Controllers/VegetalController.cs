using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetalController : ControllerBase
    {
        public IVegetalDomini VegetalDomini { get; set; }

        public VegetalController(IVegetalDomini vegetalDomini)
        {
            VegetalDomini = vegetalDomini;
        }

        [HttpGet]
        public async Task<IList<VegetalDto>> Get()
        {
            return await VegetalDomini.GetAll();
        }

        [HttpGet("id")]
        public async Task<VegetalDto> Get(int id)
        {
            return await VegetalDomini.Get(id);
        }

        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            return await VegetalDomini.Delete(id);
        }

        [HttpPost]
        public async Task<VegetalDto> Post([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Post(vegetal);
        }

        [HttpPut]
        public async Task<VegetalDto> Put([FromBody] VegetalDto vegetal)
        {
            return await VegetalDomini.Put(vegetal);
        }
    }
}
