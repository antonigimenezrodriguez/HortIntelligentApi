using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.EntityFramework;
using HortIntelligent.Dades.Repositoris.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligent.Dades.Repositoris.Implementacions
{
    public class CampRepository : ICampRepository
    {
        private readonly HortIntelligentDbContext context;

        public CampRepository(HortIntelligentDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Camp entity)
        {
            await context.Camps.AddAsync(entity);
        }


        public async Task DeleteAsync(int id)
        {
            Camp camp = await GetAsync(id);
            if (camp != null)
                context.Entry<Camp>(camp).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(Camp entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Camp>(entity).State = EntityState.Deleted;
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await context.Camps.AnyAsync(c => c.Id == id);
        }

        public async Task<IList<Camp>> GetAllAsync()
        {
            return await context.Camps
                .Include(i => i.Vegetal)
                .ToListAsync();
        }

        public async Task<Camp> GetAsync(int id)
        {
            return await context.Camps
                .Include(i => i.Vegetal)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Camp entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Camp>(entity).State = EntityState.Modified;
            });
        }
    }
}
