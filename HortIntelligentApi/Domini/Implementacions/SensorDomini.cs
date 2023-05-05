using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class SensorDomini : ISensorDomini
    {
        public ISensorRepository SensorRepository { get; set; }

        public SensorDomini(ISensorRepository sensorRepository)
        {
            SensorRepository = sensorRepository;
        }

        public async Task<IList<SensorDto>> GetAll()
        {
            return await SensorRepository.GetAll();
        }

        public async Task<SensorDto> Get(int id)
        {
            return await SensorRepository.Get(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await SensorRepository.Delete(id);
        }

        public async Task<SensorDto> Post(SensorDto sensorDto)
        {
            return await SensorRepository.Post(sensorDto);
        }

        public async Task<SensorDto> Put(SensorDto sensorDto)
        {
            return await SensorRepository.Put(sensorDto);
        }
    }
}
