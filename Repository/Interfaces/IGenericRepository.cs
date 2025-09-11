namespace OneHelper.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(int userId);
        Task<TEntity?> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(int entity);
        Task UpdateAsync(int id);
    }
}
