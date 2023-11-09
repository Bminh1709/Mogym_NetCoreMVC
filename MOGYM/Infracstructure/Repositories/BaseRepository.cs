using MOGYM.Infracstructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace MOGYM.Infracstructure.Repositories
{
    public class BaseRepository<TResponse, Key> : IGenericRepository<TResponse, Key> where TResponse : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse> Get(Key key)
        {
            return await _dbContext.Set<TResponse>().FindAsync(key);
        }

        public async Task<IEnumerable<TResponse>> GetAll()
        {
            return await _dbContext.Set<TResponse>().ToListAsync();
        }

        public async Task<TResponse> Create(TResponse request)
        {
            _dbContext.Set<TResponse>().Add(request);
            await _dbContext.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Update(Key key, TResponse request)
        {
            var entity = await _dbContext.Set<TResponse>().FindAsync(key);
            if (entity != null)
            {
                _dbContext.Update(request);
                var saved = await _dbContext.SaveChangesAsync();
                return saved > 0;
            }
            return false;
        }

        public async Task<bool> Delete(Key key)
        {
            var entity = await _dbContext.Set<TResponse>().FindAsync(key);
            if (entity != null)
            {
                _dbContext.Set<TResponse>().Remove(entity);
                var deleted = await _dbContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }
    }

}
