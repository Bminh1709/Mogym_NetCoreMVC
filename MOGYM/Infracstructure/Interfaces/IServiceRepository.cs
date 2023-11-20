using MOGYM.Models;

namespace MOGYM.Infracstructure.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ServiceModel>> GetServices(string filter);
    }
}
