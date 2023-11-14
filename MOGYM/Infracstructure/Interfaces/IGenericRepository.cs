namespace MOGYM.Infracstructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(T model);
    }
}
