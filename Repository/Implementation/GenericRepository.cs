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
            await _applicationDbContext.SaveChangesAsync();
        }

        public void DeleteAsync(TEntity entity)
        {
             _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
