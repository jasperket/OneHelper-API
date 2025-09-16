using Microsoft.EntityFrameworkCore;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using System.Threading.Tasks;

namespace OneHelper.Repository.UserRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
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

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found.....");
            }
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(int userId)
        {
            return await _dbSet.Where(i => i.Id == userId ).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
            
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Update operation failed....");
            }
        }

        public async Task UpdateAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found....");
            }
        }
    }
}
