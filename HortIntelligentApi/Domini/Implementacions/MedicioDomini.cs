using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class MedicioDomini : IMedicioDomini
    {
        public IMedicioRepository MedicioRepository { get; set; }
        private readonly IMapper mapper;


        public MedicioDomini(IMedicioRepository medicioRepository, IMapper mapper)
        {
            MedicioRepository = medicioRepository;
            this.mapper = mapper;
        }

        public async Task<IList<MedicioDto>> GetAll()
        {
            return mapper.Map<IList<MedicioDto>>(await MedicioRepository.GetAllAsync());
        }

        public async Task<MedicioDto> Get(int id)
        {
            return mapper.Map<MedicioDto>(await MedicioRepository.GetAsync(id));
        }

        public async Task<IList<MedicioDto>> GetByCampId(int campId)
        {
            return mapper.Map<IList<MedicioDto>>(await MedicioRepository.GetByCampIdAsync(campId));
        }

        public async Task<IList<MedicioDto>> GetByVegetalId(int vegetalId)
        {
            return mapper.Map<IList<MedicioDto>>(await MedicioRepository.GetByVegetalIdAsync(vegetalId));
        }

        public async Task<IList<MedicioDto>> GetBySensorId(int sensorId)
        {
            return mapper.Map<IList<MedicioDto>>(await MedicioRepository.GetBySensorId(sensorId));
        }

        public async Task<bool> Delete(int id)
        {
            var exists = await MedicioRepository.ExitsAsync(id);
            if (!exists)
            {
                return await Task.FromResult(false);
            }
            else
            {
                await MedicioRepository.DeleteAsync(id);
                int saveResult = await MedicioRepository.SaveAsync();
                if (saveResult > 0)
                    return await Task.FromResult(true);
                else
                    return await Task.FromResult(false);

            }
        }

        public async Task<MedicioDto> Post(MedicioDto medicioDto)
        {
            var sensor = mapper.Map<Medicio>(medicioDto);
            await MedicioRepository.AddAsync(sensor);
            int saveResult = await MedicioRepository.SaveAsync();
            return await Task.FromResult(mapper.Map<MedicioDto>(sensor));
        }
    }
}
