using MOGYM.Models;

namespace MOGYM.Infracstructure.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable<BranchModel>> GetBranches();
    }
}
