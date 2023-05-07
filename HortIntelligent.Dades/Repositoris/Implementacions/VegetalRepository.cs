using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.EntityFramework;
using HortIntelligent.Dades.Repositoris.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligent.Dades.Repositoris.Implementacions
{
    public class VegetalRepository : IVegetalRepository
    {
        private readonly HortIntelligentDbContext context;

        public VegetalRepository(HortIntelligentDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Vegetal entity)
        {
            await context.Vegetals.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Vegetal vegetal = await GetAsync(id);
            if (vegetal != null)
                context.Entry<Vegetal>(vegetal).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(Vegetal entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Vegetal>(entity).State = EntityState.Deleted;
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await context.Vegetals.AnyAsync(c => c.Id == id);
        }

        public async Task<IList<Vegetal>> GetAllAsync()
        {
            return await context.Vegetals
                            .Include(i => i.Camps)
                            .Include(i => i.Medicions)
                            .ToListAsync();
        }

        public async Task<Vegetal> GetAsync(int id)
        {
            return await context.Vegetals
                            .Include(i => i.Camps)
                            .Include(i => i.Medicions)
                            .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vegetal entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Vegetal>(entity).State = EntityState.Modified;
            });
        }
    }
}
