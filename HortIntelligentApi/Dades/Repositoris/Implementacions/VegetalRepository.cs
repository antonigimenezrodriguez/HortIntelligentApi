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
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
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

        public async Task<VegetalDto> Post(VegetalDto vegetal)
        {
            Vegetal vegetalAInsertar = VegetalFactory.CrearVegetal(vegetal);
            await _context.Vegetals.AddAsync(vegetalAInsertar);
            await _context.SaveChangesAsync();
            return await Task.FromResult(mapper.Map<VegetalDto>(vegetalAInsertar));
        }
    }
}
