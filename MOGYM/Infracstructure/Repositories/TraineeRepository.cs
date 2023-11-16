using Microsoft.EntityFrameworkCore;
using MOGYM.Infracstructure.Interfaces;
using MOGYM.Models;

namespace MOGYM.Infracstructure.Repositories
{
    public class TraineeRepository : BaseRepository<TraineeModel>, ITraineeRepository
    {
        public TraineeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<bool> IsExist(int id)
        //{
        //    return await _entities.AnyAsync(u => u.Id == id);
        //}
    }
}
