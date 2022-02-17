using CRUDCliente.Shared.Enums;
using CRUDCliente.Shared.Extensions;
using Newtonsoft.Json;

namespace CRUDCliente.Shared.Responses
{
    public class Response
    {
        [JsonProperty(Order = -9)]
        public ResponseType Status { get; private set; }

        [JsonProperty(Order = -8)]
        public string Type { get; private set; }

        public Response(ResponseType status)
        {
            Status = status;
            Type = status.GetDescription();
        }

        public void SetStatus(ResponseType status)
        {
            Status = status;
            Type = status.GetDescription();
        }
    }
}