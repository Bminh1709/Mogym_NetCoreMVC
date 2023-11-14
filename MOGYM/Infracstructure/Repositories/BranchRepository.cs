using Microsoft.EntityFrameworkCore;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class BranchRepository : BaseRepository<BranchModel>, IBranchRepository
    {
        public BranchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<BranchModel>> GetBranches()
        {
            return await _dbContext.Set<BranchModel>().ToListAsync();
        }
    }
}
