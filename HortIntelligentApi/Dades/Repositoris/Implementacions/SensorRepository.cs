using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Factories;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class SensorRepository : ISensorRepository
    {
        private readonly HortIntelligentDbContext context;
        private readonly IMapper mapper;

        public SensorRepository(IMapper mapper, HortIntelligentDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var sensor = await context.Sensors.FindAsync(id);
            if (sensor != null)
            {
                try
                {
                    context.Sensors.Remove(sensor);
                    await context.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(false);
                }
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<SensorDto> Get(int id)
        {
            return mapper.Map<SensorDto>(await context.Sensors.FindAsync(id));
        }

        public async Task<IList<SensorDto>> GetAll()
        {
            return await mapper.ProjectTo<SensorDto>(context.Sensors).ToListAsync();
        }

        public async Task<SensorDto> Post(SensorDto sensorDto)
        {
            Sensor sensorAInsertar = SensorFactory.CrearSensor(sensorDto);
            await context.Sensors.AddAsync(sensorAInsertar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<SensorDto>(sensorAInsertar));
        }

        public async Task<SensorDto> Put(SensorDto sensorDto)
        {
            Sensor sensorAEditar = await context.Sensors.FindAsync(sensorDto.Id);
            if (sensorAEditar == null)
            {
                return null;
            }
            sensorAEditar.Actualitzar(sensorDto);
            context.Sensors.Update(sensorAEditar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<SensorDto>(sensorAEditar));

        }
    }
}
