using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Core.Abstractions.Clientes.PostCliente;
using CRUDCliente.Data.Queries.SingleResult.Clientes;
using CRUDCliente.Domain.Clientes;
using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Extensions;
using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Handlers.Clientes.PostCliente
{
    public class PostClienteHandler : IRequestHandler<PostClienteRequest, Response>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public PostClienteHandler(IBaseRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Response> Handle(PostClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Find(new GetClienteByCpfQuery(request.Cpf.OnlyDigits().Trim()), false);

            if (cliente != null)
            {
                return new ErrorResponse(ResponseType.UnprocessableEntity)
                   .AddErrors("message", "Já existe um cliente com esse Cpf na base.");
            }

            var entidade = new Cliente()
            {
                Nome = request.Nome.Trim(),
                Cpf = request.Cpf.OnlyDigits().Trim(),
                Email = request.Email?.Trim(),
                Celular = request.Celular?.OnlyDigits().Trim(),
            };

            await _clienteRepository.Add(entidade);

            var response = new PostClienteResponse
            {
                Id = entidade.Id
            };

            return new SuccessResponse<PostClienteResponse>(ResponseType.Created, response);
        }
    }
}