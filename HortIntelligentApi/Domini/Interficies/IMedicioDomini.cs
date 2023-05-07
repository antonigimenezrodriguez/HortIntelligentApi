using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IMedicioDomini
    {
        public Task<IList<MedicioDto>> GetAll();
        public Task<MedicioDto> Get(int id);
        public Task<IList<MedicioDto>> GetByCampId(int campId);
        public Task<IList<MedicioDto>> GetByVegetalId(int vegetalId);
        public Task<IList<MedicioDto>> GetBySensorId(int sensorId);
        public Task<bool> Delete(int id);
        public Task<MedicioDto> Post(MedicioDto medicioDto);
        public Task<bool> ExisteixCamp(int campId);
        public Task<bool> ExisteixVegetal(int vegetalId);
        public Task<bool> ExisteixSensor(int sensorId);
        public Task<bool> Exists(int id);
    }
}
