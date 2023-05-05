using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Dades.Repositoris.Interficies
{
    public interface IMedicioRepository
    {
        public Task<IList<MedicioDto>> GetAll();
        public Task<MedicioDto> Get(int id);
        public Task<IList<MedicioDto>> GetByCampId(int campId);
        public Task<IList<MedicioDto>> GetByVegetalId(int vegetalId);
        public Task<IList<MedicioDto>> GetBySensorId(int sensorId);
        public Task<bool> Delete(int id);
        public Task<MedicioDto> Post(MedicioDto medicioDto);
    }
}
