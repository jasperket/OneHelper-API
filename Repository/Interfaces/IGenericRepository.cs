namespace OneHelper.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
