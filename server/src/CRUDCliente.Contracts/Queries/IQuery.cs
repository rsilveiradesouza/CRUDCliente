using CRUDCliente.Shared.Enums;
using System.Linq.Expressions;

namespace CRUDCliente.Contracts.Queries
{
    public interface IQuery<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Inclusions { get; }
        List<string> SubInclusions { get; }
        List<Expression<Func<T, object>>> ExcludedFields { get; }

        int PageSize { get; }
        int PageNumber { get; }
        string OrderBy { get; }
        OrderDirection OrderDirection { get; }
    }
}