using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Abstractions.Clientes.GetCliente
{
    public class GetClienteRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
