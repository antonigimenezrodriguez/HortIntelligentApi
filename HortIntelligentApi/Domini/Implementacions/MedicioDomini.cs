using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class MedicioDomini : IMedicioDomini
    {
        public IMedicioRepository MedicioRepository { get; set; }

        public MedicioDomini(IMedicioRepository medicioRepository)
        {
            MedicioRepository = medicioRepository;
        }

        public async Task<IList<MedicioDto>> GetAll()
        {
            return await MedicioRepository.GetAll();
        }

        public async Task<MedicioDto> Get(int id)
        {
            return await MedicioRepository.Get(id);
        }

        public async Task<IList<MedicioDto>> GetByCampId(int campId)
        {
            return await MedicioRepository.GetByCampId(campId);
        }

        public async Task<IList<MedicioDto>> GetByVegetalId(int vegetalId)
        {
            return await MedicioRepository.GetByVegetalId(vegetalId);
        }

        public async Task<IList<MedicioDto>> GetBySensorId(int sensorId)
        {
            return await MedicioRepository.GetBySensorId(sensorId);
        }

        public async Task<bool> Delete(int id)
        {
            return await MedicioRepository.Delete(id);
        }

        public async Task<MedicioDto> Post(MedicioDto medicioDto)
        {
            return await MedicioRepository.Post(medicioDto);
        }
    }
}
