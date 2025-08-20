namespace OneHelper.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        TEntity GetAllAsync();
        TEntity GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
