using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Factories;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class CampRepository : ICampRepository
    {
        private readonly HortIntelligentDbContext context;
        private readonly IMapper mapper;

        public CampRepository(IMapper mapper, HortIntelligentDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var camp = await context.Camps.FindAsync(id);
            if (camp != null)
            {
                try
                {
                    context.Camps.Remove(camp);
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

        public async Task<CampDto> Get(int id)
        {
            return mapper.Map<CampDto>(await context.Camps.FindAsync(id));
        }

        public async Task<IList<CampDto>> GetAll()
        {
            return await mapper.ProjectTo<CampDto>(context.Camps).ToListAsync();
        }

        public async Task<CampDto> Post(CampDto campDto)
        {
            Camp campAInsertar = CampFactory.CrearCamp(campDto);
            await context.Camps.AddAsync(campAInsertar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<CampDto>(campAInsertar));
        }

        public async Task<CampDto> Put(CampDto campDto)
        {
            Camp campAEditar = await context.Camps.FindAsync(campDto.Id);
            if(campAEditar == null)
            {
                return null;
            }
            campAEditar.Actualitzar(campDto);
            context.Camps.Update(campAEditar);
            await context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<CampDto>(campAEditar));
        }
    }
}
