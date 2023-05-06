using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class SensorDomini : ISensorDomini
    {
        public ISensorRepository SensorRepository { get; set; }
        private readonly IMapper mapper;

        public SensorDomini(ISensorRepository sensorRepository, IMapper mapper)
        {
            SensorRepository = sensorRepository;
            this.mapper = mapper;
        }

        public async Task<IList<SensorDto>> GetAll()
        {
            return mapper.Map<IList<SensorDto>>(await SensorRepository.GetAllAsync());
        }

        public async Task<SensorDto> Get(int id)
        {
            return mapper.Map<SensorDto>(await SensorRepository.GetAsync(id));
        }

        public async Task<bool> Delete(int id)
        {
            var exists = await SensorRepository.ExitsAsync(id);
            if (!exists)
            {
                return await Task.FromResult(false);
            }
            else
            {
                await SensorRepository.DeleteAsync(id);
                int saveResult = await SensorRepository.SaveAsync();
                if (saveResult > 0)
                    return await Task.FromResult(true);
                else
                    return await Task.FromResult(false);

            }
        }

        public async Task<SensorDto> Post(SensorDto sensorDto)
        {
            var sensor = mapper.Map<Sensor>(sensorDto);
            await SensorRepository.AddAsync(sensor);
            int saveResult = await SensorRepository.SaveAsync();
            return await Task.FromResult(mapper.Map<SensorDto>(sensor));
        }

        public async Task<SensorDto> Put(SensorDto sensorDto)
        {
            var sensor = mapper.Map<Sensor>(sensorDto);
            await SensorRepository.UpdateAsync(sensor);
            int saveResult = await SensorRepository.SaveAsync();
            return await Task.FromResult(mapper.Map<SensorDto>(sensor));
        }
    }
}
