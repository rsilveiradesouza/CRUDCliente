using CRUDCliente.Shared.Attributes;
using System.ComponentModel;

namespace CRUDCliente.Shared.Enums
{
    [SerializeEnumAsInt]
    public enum ResponseType
    {
        [Description("OK")]
        Ok = 200,
        [Description("CREATED")]
        Created = 201,
        [Description("NO_CONTENT")]
        NoContent = 204,
        [Description("REDIRECT")]
        [Detail("This way, please.")]
        Redirect = 302,
        [Description("BAD_REQUEST")]
        [Detail("What? Come again.")]
        BadRequest = 400,
        [Description("UNAUTHORIZED")]
        [Detail("Haha! You shaw not passss!")]
        Unauthorized = 401,
        [Description("FORBIDDEN")]
        [Detail("Mmmh! Who are you again?")]
        Forbidden = 403,
        [Description("NOT_FOUND")]
        [Detail("Ops! Resource not found.")]
        NotFound = 404,
        [Description("METHOD_NOT_ALLOWED")]
        [Detail("Nah! Nah! Nah!")]
        MethodNotAllowed = 405,
        [Description("CONFLICT")]
        [Detail("Hey! This registry already exists.")]
        Conflict = 409,
        [Description("UNPROCESSABLE_ENTITY")]
        [Detail("Omg! There is something wrong here.")]
        UnprocessableEntity = 422,
        [Description("INTERNAL_SERVER_ERROR")]
        [Detail("Ugh! I am not feeling well.")]
        InternalServerError = 500,
        [Description("BAD_GATEWAY")]
        BadGateway = 502,
        [Description("SERVICE_UNAVAILABLE")]
        ServiceUnavailable = 503,
        [Description("GATEWAY_TIMEOUT")]
        GatewayTimeout = 504
    }
}