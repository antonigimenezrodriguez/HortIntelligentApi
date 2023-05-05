using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        public ISensorDomini SensorDomini { get; set; }

        public SensorController(ISensorDomini sensorDomini)
        {
            SensorDomini = sensorDomini;
        }

        [HttpGet]
        public async Task<IList<SensorDto>> Get()
        {
            return await SensorDomini.GetAll();
        }

        [HttpGet("id")]
        public async Task<SensorDto> Get(int id)
        {
            return await SensorDomini.Get(id);
        }

        [HttpDelete("id")]
        public async Task<bool> Delete(int id)
        {
            return await SensorDomini.Delete(id);
        }

        [HttpPost]
        public async Task<SensorDto> Post([FromBody] SensorDto sensorDto)
        {
            return await SensorDomini.Post(sensorDto);
        }

        [HttpPut]
        public async Task<SensorDto> Put([FromBody] SensorDto sensorDto)
        {
            return await SensorDomini.Put(sensorDto);
        }
    }
}
