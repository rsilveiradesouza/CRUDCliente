using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Core.Abstractions.Clientes.PutCliente;
using CRUDCliente.Data.Queries.SingleResult.Clientes;
using CRUDCliente.Domain.Clientes;
using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Extensions;
using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Handlers.Clientes.PutCliente
{
    public class PutClienteHandler : IRequestHandler<PutClienteRequest, Response>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public PutClienteHandler(IBaseRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Response> Handle(PutClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Find(new GetClienteQuery(request.Id));
            var clienteNovo = await _clienteRepository.Find(new GetClienteByCpfQuery(request.Cpf.OnlyDigits().Trim()), false);

            if (cliente == null)
            {
                return new ErrorResponse(ResponseType.NotFound)
                   .AddErrors("message", "Cliente não encontrado.");
            }

            if (clienteNovo != null && clienteNovo.Id != request.Id)
            {
                return new ErrorResponse(ResponseType.UnprocessableEntity)
                   .AddErrors("message", "Já existe um cliente com esse Cpf na base.");
            }

            cliente.Nome = request.Nome.Trim();
            cliente.Cpf = request.Cpf.OnlyDigits().Trim();
            cliente.Celular = request.Celular?.OnlyDigits().Trim();
            cliente.Email = request.Email?.Trim();

            await _clienteRepository.Update(cliente);

            var response = new PutClienteResponse
            {
                Id = cliente.Id
            };

            return new SuccessResponse<PutClienteResponse>(ResponseType.Ok, response);
        }
    }
}