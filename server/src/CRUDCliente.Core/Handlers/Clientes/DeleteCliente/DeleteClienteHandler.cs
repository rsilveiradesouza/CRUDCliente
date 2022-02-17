using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Core.Abstractions.Clientes.DeleteCliente;
using CRUDCliente.Data.Queries.SingleResult.Clientes;
using CRUDCliente.Domain.Clientes;
using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Handlers.Clientes.DeleteCliente
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteRequest, Response>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public DeleteClienteHandler(IBaseRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Response> Handle(DeleteClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Find(new GetClienteQuery(request.Id));

            if (cliente == null)
            {
                return new ErrorResponse(ResponseType.NotFound)
                   .AddErrors("message", "Cliente não encontrado.");
            }

            await _clienteRepository.Remove(cliente);

            return new Response(ResponseType.NoContent);
        }
    }
}