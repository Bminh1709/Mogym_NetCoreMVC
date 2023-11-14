using MOGYM.Models;

namespace MOGYM.Infracstructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<UserModel> UserRepository { get; }
        IGenericRepository<BranchModel> BranchRepository { get; }
        IGenericRepository<TrainerModel> TrainerRepository { get; }
        IGenericRepository<TraineeModel> TraineeRepository { get; }
        IGenericRepository<AdminModel> AdminRepository { get; }

        void SaveChanges();
    }
}
