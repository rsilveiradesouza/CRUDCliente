using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Abstractions.Clientes.GetClientes
{
    public class GetClientesRequest : IRequest<Response>
    {
        public string? NomeCompleto { get; set; }
    }
}
