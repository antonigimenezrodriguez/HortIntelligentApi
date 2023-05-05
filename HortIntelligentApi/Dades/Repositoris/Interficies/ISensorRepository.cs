using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Dades.Repositoris.Interficies
{
    public interface ISensorRepository
    {
        public Task<IList<SensorDto>> GetAll();
        public Task<SensorDto> Get(int id);
        public Task<bool> Delete(int id);
        public Task<SensorDto> Post(SensorDto sensorDto);
        public Task<SensorDto> Put(SensorDto sensorDto);
    }
}
