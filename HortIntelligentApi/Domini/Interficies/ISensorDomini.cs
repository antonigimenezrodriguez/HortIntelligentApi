using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface ISensorDomini
    {
        public Task<IList<SensorDto>> GetAll();
        public Task<SensorDto> Get(int id);
        public Task<bool> Delete(int id);
        public Task<SensorDto> Post(SensorDto sensorDto);
        public Task<SensorDto> Put(SensorDto sensorDto);
        public Task<bool> Exists(int sensorId);
    }
}
