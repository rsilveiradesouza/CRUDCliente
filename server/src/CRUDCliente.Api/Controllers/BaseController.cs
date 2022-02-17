using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CRUDCliente.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResult(Response response)
        {
            return response.Status switch
            {
                ResponseType.NoContent => NoContent(),
                ResponseType.UnprocessableEntity => UnprocessableEntity(response),
                ResponseType.BadRequest => BadRequest(response),
                ResponseType.NotFound => NotFound(response),
                ResponseType.Unauthorized => Unauthorized(response),
                _ => Conflict(response)
            };
        }

        protected IActionResult CreateGetResult<T>(Response response)
        {
            return response.Status switch
            {
                ResponseType.Ok => Ok((response as SuccessResponse<T>).Data),
                ResponseType.UnprocessableEntity => UnprocessableEntity(response),
                ResponseType.NotFound => NotFound(response),
                ResponseType.BadRequest => BadRequest(response),
                ResponseType.Unauthorized => Unauthorized(response),
                _ => Conflict(response)
            };
        }

        protected IActionResult CreatePostResult<T>(Response response, [CallerMemberName] string functionName = null)
        {
            return response.Status switch
            {
                ResponseType.Ok => Ok((response as SuccessResponse<T>).Data),
                ResponseType.Created => Created(functionName, (response as SuccessResponse<T>).Data),
                ResponseType.UnprocessableEntity => UnprocessableEntity(response),
                ResponseType.Unauthorized => Unauthorized(response),
                ResponseType.BadRequest => BadRequest(response),
                ResponseType.NotFound => NotFound(response),
                _ => Conflict(response)
            };
        }

        protected IActionResult CreatePutResult<T>(Response response, [CallerMemberName] string functionName = null)
        {
            return response.Status switch
            {
                ResponseType.Ok => Ok((response as SuccessResponse<T>).Data),
                ResponseType.Created => Created(functionName, (response as SuccessResponse<T>).Data),
                ResponseType.UnprocessableEntity => UnprocessableEntity(response),
                ResponseType.Unauthorized => Unauthorized(response),
                ResponseType.BadRequest => BadRequest(response),
                ResponseType.NotFound => NotFound(response),
                _ => Conflict(response)
            };
        }
    }
}