using CRUDCliente.Contracts.Queries;
using CRUDCliente.Domain;

namespace CRUDCliente.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> Find<TQuery>(TQuery query, bool useTracking = true) where TQuery : ISingleResultQuery<T>;
        Task<(IEnumerable<T>, int)> FindList<TQuery>(TQuery query, bool useTracking = true) where TQuery : IListResultQuery<T>;
        Task<IEnumerable<T>> FindList(bool useTracking = true);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<T> FindById(Guid id, bool useTracking = true);
    }
}