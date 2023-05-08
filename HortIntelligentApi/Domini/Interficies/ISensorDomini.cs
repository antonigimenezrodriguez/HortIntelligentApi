using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface ISensorDomini
    {
        public Task<ResultDto<IList<SensorDto>>> GetAll();
        public Task<ResultDto<SensorDto>> Get(int id);
        public Task<ResultDto<int>> Delete(int id);
        public Task<ResultDto<SensorDto>> Post(SensorDto sensorDto);
        public Task<ResultDto<SensorDto>> Put(SensorDto sensorDto);
        public Task<bool> Exists(int sensorId);
    }
}
