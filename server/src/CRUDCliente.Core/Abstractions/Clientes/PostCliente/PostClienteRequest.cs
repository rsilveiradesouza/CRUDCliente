using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Abstractions.Clientes.PostCliente
{
    public class PostClienteRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
    }
}
