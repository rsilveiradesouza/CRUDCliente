using CRUDCliente.Contracts.Queries;
using CRUDCliente.Data.Specifications;
using CRUDCliente.Domain.Clientes;

namespace CRUDCliente.Data.Queries.SingleResult.Clientes
{
    public class GetClienteQuery : Query<Cliente>, ISingleResultQuery<Cliente>
    {
        public GetClienteQuery(Guid idCliente) : base(x => x.Id == idCliente)
        {
        }
    }
}
