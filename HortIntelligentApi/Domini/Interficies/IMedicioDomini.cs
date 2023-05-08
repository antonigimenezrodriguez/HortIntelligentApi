using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IMedicioDomini
    {
        public Task<ResultDto<IList<MedicioDto>>> GetAll();
        public Task<ResultDto<MedicioDto>> Get(int id);
        public Task<ResultDto<IList<MedicioDto>>> GetByCampId(int campId);
        public Task<ResultDto<IList<MedicioDto>>> GetByVegetalId(int vegetalId);
        public Task<ResultDto<IList<MedicioDto>>> GetBySensorId(int sensorId);
        public Task<ResultDto<int>> Delete(int id);
        public Task<ResultDto<MedicioDto>> Post(MedicioDto medicioDto);
        public Task<bool> ExisteixCamp(int campId);
        public Task<bool> ExisteixVegetal(int vegetalId);
        public Task<bool> ExisteixSensor(int sensorId);
        public Task<bool> Exists(int id);
    }
}
