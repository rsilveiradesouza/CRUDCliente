using AutoMapper;
using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Core.Abstractions.Clientes.GetClientes;
using CRUDCliente.Data.Queries.ListResult.Clientes;
using CRUDCliente.Domain.Clientes;
using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Responses;
using MediatR;

namespace CRUDCliente.Core.Handlers.Clientes.GetClientes
{
    public class GetClientesHandler : IRequestHandler<GetClientesRequest, Response>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public GetClientesHandler(IMapper mapper,
            IBaseRepository<Cliente> clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<Response> Handle(GetClientesRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.FindList(new GetClientesQuery(request.NomeCompleto?.Trim()), false);

            var response = _mapper.Map<IEnumerable<GetClientesResponse>>(clientes.Item1);

            return new SuccessResponse<IEnumerable<GetClientesResponse>>(ResponseType.Ok, response);
        }
    }
}