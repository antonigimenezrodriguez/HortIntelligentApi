using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.EntityFramework;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligentApi.Dades.Repositoris.Implementacions
{
    public class VegetalRepository : IVegetalRepository
    {
        private readonly HortIntelligentDbContext _context;

        public VegetalRepository(HortIntelligentDbContext context)
        {
            this._context = context;
        }
        public async Task<IList<Vegetal>> GetAll()
        {
            return await _context.Vegetals.ToListAsync();
        }
    }
}
