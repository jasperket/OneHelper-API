using OneHelper.Repository.Interfaces;

namespace OneHelper.Repository.UserRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository() { 
            
        }
        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
