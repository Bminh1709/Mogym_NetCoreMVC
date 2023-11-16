using MOGYM.Infracstructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MOGYM.Infracstructure.Repositories
{
    public class BaseRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<T> _entities;
        protected bool _disposed = false;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public virtual async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Create(T model)
        {
            _entities.Add(model);
            var created = await _dbContext.SaveChangesAsync();
            return created > 0;
        }

        public virtual async Task<bool> Update(T model)
        {       
            _dbContext.Update(model);
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0;
        }

        public virtual async Task<bool> Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        // Method to perform actual cleanup
        protected virtual void Dispose(bool disposing)
        {
            // Check if the object has not been disposed
            if (!_disposed)
            {
                // If disposing is true, it means Dispose is called explicitly by client code
                if (disposing)
                {
                    // Release managed resources (in this case, the _dbContext object)
                    _dbContext.Dispose();
                }

                // Set the disposed flag to true to indicate that the object has been disposed
                _disposed = true;
            }
        }

        // Public method that clients call to dispose of the object
        public void Dispose()
        {
            // The object will be cleaned up by the Dispose method.
            Dispose(true);
            // Call GC.SuppressFinalize to take this object off the finalization queue
            // Prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }
    }

}
