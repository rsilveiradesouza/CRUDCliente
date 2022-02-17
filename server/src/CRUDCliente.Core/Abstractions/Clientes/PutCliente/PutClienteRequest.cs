using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Abstractions.Clientes.PutCliente
{
    public class PutClienteRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
    }
}
