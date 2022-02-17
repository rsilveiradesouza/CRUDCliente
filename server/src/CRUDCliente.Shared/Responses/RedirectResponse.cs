using CRUDCliente.Shared.Enums;

namespace CRUDCliente.Shared.Responses
{
    public class RedirectResponse : Response
    {
        public string RedirectUrl { get; private set; }

        public RedirectResponse(ResponseType status, string redirectUrl) : base(status) => RedirectUrl = redirectUrl;

        public new RedirectResponse SetStatus(ResponseType status)
        {
            base.SetStatus(status);
            return this;
        }
        public RedirectResponse SetRedirectUrl(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
            return this;
        }
    }
}