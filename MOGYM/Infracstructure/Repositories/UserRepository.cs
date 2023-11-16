using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<UserModel>> GetUsers(string filter)
        {
            IQueryable<UserModel> query = _dbContext.Set<UserModel>().Where(u => !(u is AdminModel));

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(u => u.Name.Contains(filter) || u.Gmail.Contains(filter));
            }

            return await query.ToListAsync();
        }
        public async Task<UserModel> GetUserBranch(int id)
        {
            return await _entities.AsNoTracking().Include(b => b.Branch).Where(u => u.Id == id).SingleOrDefaultAsync();
        }

        public async Task<UserModel> GetUser(string gmail)
        {
            return await _entities.AsNoTracking().Where(u => u.Gmail == gmail).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExist(string gmail)
        {
            return await _entities.AnyAsync(u => u.Gmail == gmail);
        }

    }
}
