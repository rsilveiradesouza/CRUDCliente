using CRUDCliente.Contracts.Queries;
using CRUDCliente.Data.Specifications;
using CRUDCliente.Domain.Clientes;

namespace CRUDCliente.Data.Queries.SingleResult.Clientes
{
    public class GetClienteByCpfQuery : Query<Cliente>, ISingleResultQuery<Cliente>
    {
        public GetClienteByCpfQuery(string cpf) : base(x => x.Cpf == cpf)
        {
        }
    }
}
