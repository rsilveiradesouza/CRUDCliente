using CRUDCliente.Core.Abstractions.Clientes.DeleteCliente;
using CRUDCliente.Core.Abstractions.Clientes.GetCliente;
using CRUDCliente.Core.Abstractions.Clientes.GetClientes;
using CRUDCliente.Core.Abstractions.Clientes.PostCliente;
using CRUDCliente.Core.Abstractions.Clientes.PutCliente;
using CRUDCliente.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCliente.Api.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Listar clientes</summary>
        /// <remarks>Lista clientes</remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Autorização não informado ou inválido</response>
        /// <response code="403">Sem autorização para acessar o recurso solicitado</response>
        /// <response code="422">Erro de negócio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<GetClientesResponse>>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetClientes([FromQuery] GetClientesRequest request)
        {
            var response = await _mediator.Send(request);

            return CreateGetResult<IEnumerable<GetClientesResponse>>(response);
        }

        /// <summary>Obter Cliente</summary>
        /// <remarks>Obtem Cliente</remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Autorização não informado ou inválido</response>
        /// <response code="403">Sem autorização para acessar o recurso solicitado</response>
        /// <response code="422">Erro de negócio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(SuccessResponse<GetClienteResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetCliente([FromRoute] GetClienteRequest request)
        {
            var response = await _mediator.Send(request);

            return CreateGetResult<GetClienteResponse>(response);
        }

        /// <summary>Excluir Cliente</summary>
        /// <remarks>Exclui Cliente</remarks>
        /// <response code="204">No Content</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Autorização não informado ou inválido</response>
        /// <response code="403">Sem autorização para acessar o recurso solicitado</response>
        /// <response code="422">Erro de negócio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Response), 204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> DeleteCliente([FromRoute] DeleteClienteRequest request)
        {
            var response = await _mediator.Send(request);

            return CreateResult(response);
        }

        /// <summary>Editar Cliente</summary>
        /// <remarks>Edita Cliente</remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Autorização não informado ou inválido</response>
        /// <response code="403">Sem autorização para acessar o recurso solicitado</response>
        /// <response code="422">Erro de negócio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPut("")]
        [ProducesResponseType(typeof(SuccessResponse<PutClienteResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> PutCliente([FromBody] PutClienteRequest request)
        {
            var response = await _mediator.Send(request);

            return CreatePutResult<PutClienteResponse>(response);
        }

        /// <summary>Adicionar Cliente</summary>
        /// <remarks>Adiciona Cliente</remarks>
        /// <response code="201">Created</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Autorização não informado ou inválido</response>
        /// <response code="403">Sem autorização para acessar o recurso solicitado</response>
        /// <response code="422">Erro de negócio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(SuccessResponse<PostClienteResponse>), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        [ProducesResponseType(typeof(ErrorResponse), 409)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> PostCliente([FromBody] PostClienteRequest request)
        {
            var response = await _mediator.Send(request);

            return CreatePostResult<PostClienteResponse>(response);
        }
    }
}