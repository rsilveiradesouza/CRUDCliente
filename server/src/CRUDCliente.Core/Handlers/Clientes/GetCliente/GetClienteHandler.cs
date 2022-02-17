using AutoMapper;
using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Core.Abstractions.Clientes.GetCliente;
using CRUDCliente.Data.Queries.SingleResult.Clientes;
using CRUDCliente.Domain.Clientes;
using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Handlers.Clientes.GetCliente
{
    public class GetClienteHandler : IRequestHandler<GetClienteRequest, Response>
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public GetClienteHandler(IBaseRepository<Cliente> clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Find(new GetClienteQuery(request.Id), false);

            if (cliente == null)
            {
                return new ErrorResponse(ResponseType.NotFound)
                   .AddErrors("message", "Cliente não encontrado.");
            }

            var response = _mapper.Map<GetClienteResponse>(cliente);

            return new SuccessResponse<GetClienteResponse>(ResponseType.Ok, response);
        }
    }
}