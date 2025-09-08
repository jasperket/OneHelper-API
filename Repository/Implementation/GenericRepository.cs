using Microsoft.EntityFrameworkCore;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using System.Threading.Tasks;

namespace OneHelper.Repository.UserRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        readonly OneHelperContext _applicationDbContext;
        readonly DbSet<TEntity> _dbSet;
        public GenericRepository(OneHelperContext context) { 
            _applicationDbContext = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                throw new Exception("User not found.....");
            }
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                throw new Exception("User not found....");
            }
        }
    }
}
