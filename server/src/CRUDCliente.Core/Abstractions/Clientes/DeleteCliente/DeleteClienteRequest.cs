using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Abstractions.Clientes.DeleteCliente
{
    public class DeleteClienteRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
