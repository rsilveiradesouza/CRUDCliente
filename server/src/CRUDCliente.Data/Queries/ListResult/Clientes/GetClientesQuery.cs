using CRUDCliente.Contracts.Queries;
using CRUDCliente.Data.Specifications;
using CRUDCliente.Domain.Clientes;

namespace CRUDCliente.Data.Queries.ListResult.Clientes
{
    public class GetClientesQuery : Query<Cliente>, IListResultQuery<Cliente>
    {
        public GetClientesQuery(string? nomeCompleto = "") :
            base(c => string.IsNullOrWhiteSpace(nomeCompleto) || c.Nome.ToLower().Contains(nomeCompleto.ToLower()))
        {
        }
    }
}
