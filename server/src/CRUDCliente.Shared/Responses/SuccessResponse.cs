using CRUDCliente.Shared.Enums;

namespace CRUDCliente.Shared.Responses
{
    public class SuccessResponse<T> : Response
    {
        public T Data { get; private set; }

        public SuccessResponse(ResponseType status, T data) : base(status) => Data = data;

        public new SuccessResponse<T> SetStatus(ResponseType status)
        {
            base.SetStatus(status);
            return this;
        }
        public SuccessResponse<T> SetData(T data)
        {
            Data = data;
            return this;
        }
    }
}