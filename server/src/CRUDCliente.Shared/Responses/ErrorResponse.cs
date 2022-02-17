using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Extensions;
using System.Dynamic;

namespace CRUDCliente.Shared.Responses
{
    public class ErrorResponse : Response
    {
        public string Detail { get; private set; }
        public ExpandoObject Errors { get; private set; }
        public bool HasErrors { get; private set; } = false;

        public ErrorResponse(ResponseType status) : base(status)
        {
            Detail = status.GetDetail();
            Errors = new ExpandoObject();
        }

        public ErrorResponse AddErrors(string key, string value)
        {
            var _keys = Array.ConvertAll(key.Split("."), s => s);
            var _key = string.Join(".", _keys);
            Errors.TryAdd(_key, value);
            HasErrors = true;

            return this;
        }
    }
}