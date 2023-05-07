using HortIntelligent.Dades.Entitats;

namespace HortIntelligent.Dades.Repositoris.Interficies
{
    public interface IMedicioRepository : IRepository<Medicio>
    {
        Task<IList<Medicio>> GetByCampIdAsync(int campId);
        Task<IList<Medicio>> GetBySensorId(int sensorId);
        Task<IList<Medicio>> GetByVegetalIdAsync(int vegetalId);
    }
}
