namespace HortIntelligent.Dades.Repositoris.Interficies
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);
        Task<bool> ExitsAsync(int id);
        Task<int> SaveAsync();
    }
}
