using Microsoft.EntityFrameworkCore;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class AdminRepository : BaseRepository<AdminModel>, IAdminRepository
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
