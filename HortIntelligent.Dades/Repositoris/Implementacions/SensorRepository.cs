using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.EntityFramework;
using HortIntelligent.Dades.Repositoris.Interficies;
using Microsoft.EntityFrameworkCore;

namespace HortIntelligent.Dades.Repositoris.Implementacions
{
    public class SensorRepository : ISensorRepository
    {
        private readonly HortIntelligentDbContext context;

        public SensorRepository(HortIntelligentDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Sensor entity)
        {
            await context.Sensors.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Sensor sensor = await GetAsync(id);
            if (sensor != null)
                context.Entry<Sensor>(sensor).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(Sensor entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Sensor>(entity).State = EntityState.Deleted;
            });
        }

        public async Task<bool> ExitsAsync(int id)
        {
            return await context.Sensors.AnyAsync(c => c.Id == id);
        }

        public async Task<IList<Sensor>> GetAllAsync()
        {
            return await context.Sensors
                .Include(i => i.Medicions)
                .ToListAsync();
        }

        public async Task<Sensor> GetAsync(int id)
        {
            return await context.Sensors
                .Include(i => i.Medicions)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sensor entity)
        {
            await Task.Run(() =>
            {
                context.Entry<Sensor>(entity).State = EntityState.Modified;
            });
        }
    }
}
