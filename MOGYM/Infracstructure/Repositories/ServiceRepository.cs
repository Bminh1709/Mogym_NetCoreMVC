using Microsoft.EntityFrameworkCore;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class ServiceRepository : BaseRepository<ServiceModel>, IServiceRepository
    {
        public ServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ServiceModel>> GetServices(string filter)
        {
            IQueryable<ServiceModel> query = _entities.AsNoTracking();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.Title.Contains(filter) || s.Description.Contains(filter));
            }

            return await query.ToListAsync();
        }
    }
}
