using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Http;
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
    }
}
