namespace MOGYM.Infracstructure.Interfaces
{
    public interface IGenericRepository<TResponse, Key>
    {
        Task<IEnumerable<TResponse>> GetAll();
        Task<TResponse> Get(Key key);
        Task<TResponse> Create(TResponse request);
        Task<bool> Update(Key key, TResponse request);
        Task<bool> Delete(Key key);
    }
}
