using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Factories;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class MedicioRepository : IMedicioRepository
    {
        private readonly HortIntelligentDbContext context;
        private readonly IMapper mapper;

        public MedicioRepository(IMapper mapper, HortIntelligentDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var medicio = await context.Medicions.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (medicio != null)
            {
                try
                {
                    context.Medicions.Remove(medicio);
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

        public async Task<MedicioDto> Get(int id)
        {
            return mapper.Map<MedicioDto>(await context.Medicions.Where(w => w.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IList<MedicioDto>> GetAll()
        {
            return await mapper.ProjectTo<MedicioDto>(context.Medicions).ToListAsync();
        }

        public async Task<IList<MedicioDto>> GetByCampId(int campId)
        {
            return await mapper.ProjectTo<MedicioDto>(context.Medicions.Where(w => w.CampId == campId)).ToListAsync();
        }

        public async Task<IList<MedicioDto>> GetBySensorId(int sensorId)
        {
            return await mapper.ProjectTo<MedicioDto>(context.Medicions.Where(w => w.SensorId == sensorId)).ToListAsync();
        }

        public async Task<IList<MedicioDto>> GetByVegetalId(int vegetalId)
        {
            return await mapper.ProjectTo<MedicioDto>(context.Medicions.Where(w => w.VegetalId == vegetalId)).ToListAsync();
        }

        public async Task<MedicioDto> Post(MedicioDto medicioDto)
        {
            Medicio medicioAInsertar = MedicioFactory.CrearMedicio(medicioDto);
            await context.Medicions.AddAsync(medicioAInsertar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<MedicioDto>(medicioAInsertar));
        }
    }
}
