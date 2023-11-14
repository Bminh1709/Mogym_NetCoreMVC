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

        public async Task<TraineeModel> GetTrainee(int id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
