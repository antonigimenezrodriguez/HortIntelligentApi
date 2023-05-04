using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class VegetalRepository : IVegetalRepository
    {
        private readonly HortIntelligentDbContext _context;
        private readonly IMapper mapper;

        public VegetalRepository(HortIntelligentDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var vegetal = await _context.Vegetals.FindAsync(id);
            if (vegetal != null)
            {
                _context.Vegetals.Remove(vegetal);
                return true; 
            }
            else
            {
                return await Task.FromResult(false);
            }

        }

        public async Task<VegetalDto> Get(int id)
        {
            return mapper.Map<VegetalDto>(await _context.Vegetals.FindAsync(id));
        }

        public async Task<IList<VegetalDto>> GetAll()
        {
            return await mapper.ProjectTo<VegetalDto>(_context.Vegetals).ToListAsync();
        }


    }
}
