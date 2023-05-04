using AutoMapper;
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
        private readonly IMapper mapper;

        public VegetalRepository(HortIntelligentDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<IList<VegetalDto>> GetAll()
        {
            return await mapper.ProjectTo<VegetalDto>(_context.Vegetals).ToListAsync();
        }
    }
}
