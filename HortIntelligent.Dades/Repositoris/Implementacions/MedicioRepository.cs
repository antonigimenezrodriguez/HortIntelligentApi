using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.EntityFramework;
using HortIntelligent.Dades.Repositoris.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligent.Dades.Repositoris.Implementacions
{
    public class MedicioRepository : IMedicioRepository
    {
        private readonly HortIntelligentDbContext context;

        public MedicioRepository(HortIntelligentDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Medicio entity)
        {
            await context.Medicions.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Medicio camp = await GetAsync(id);
            if (camp != null)
                context.Entry<Medicio>(camp).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(Medicio entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Medicio>(entity).State = EntityState.Deleted;
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await context.Medicions.AnyAsync(c => c.Id == id);
        }

        public async Task<IList<Medicio>> GetAllAsync()
        {
            return await context.Medicions
                .Include(i => i.Camp)
                .Include(i => i.Sensor)
                .Include(i => i.Vegetal)
                .ToListAsync();
        }

        public async Task<Medicio> GetAsync(int id)
        {
            return await context.Medicions
                .Include(i => i.Camp)
                .Include(i => i.Sensor)
                .Include(i => i.Vegetal)
                .Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Medicio>> GetByCampIdAsync(int campId)
        {
            return (await GetAllAsync()).Where(w => w.CampId == campId).ToList();
        }

        public async Task<IList<Medicio>> GetBySensorId(int sensorId)
        {
            return (await GetAllAsync()).Where(w => w.SensorId == sensorId).ToList();
        }

        public async Task<IList<Medicio>> GetByVegetalIdAsync(int vegetalId)
        {
            return (await GetAllAsync()).Where(w => w.VegetalId == vegetalId).ToList();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medicio entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Medicio>(entity).State = EntityState.Modified;
            });
        }
    }
}
