using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Factories;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class VegetalRepository : IVegetalRepository
    {
        private readonly HortIntelligentDbContext context;
        private readonly IMapper mapper;

        public VegetalRepository(HortIntelligentDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var vegetal = await context.Vegetals.FindAsync(id);
            if (vegetal != null)
            {
                try
                {
                    context.Vegetals.Remove(vegetal);
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

        public async Task<VegetalDto> Get(int id)
        {
            return mapper.Map<VegetalDto>(await context.Vegetals.FindAsync(id));
        }

        public async Task<IList<VegetalDto>> GetAll()
        {
            return await mapper.ProjectTo<VegetalDto>(context.Vegetals).ToListAsync();
        }

        public async Task<VegetalDto> Post(VegetalDto vegetal)
        {
            Vegetal vegetalAInsertar = VegetalFactory.CrearVegetal(vegetal);
            await context.Vegetals.AddAsync(vegetalAInsertar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<VegetalDto>(vegetalAInsertar));
        }

        public async Task<VegetalDto> Put(VegetalDto vegetal)
        {
            Vegetal vegetalAEditar = await context.Vegetals.FindAsync(vegetal.Id);
            if (vegetalAEditar == null)
            {
                return null;
            }
            vegetalAEditar.Actualitzar(vegetal);
            context.Vegetals.Update(vegetalAEditar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<VegetalDto>(vegetalAEditar));
        }
    }
}
