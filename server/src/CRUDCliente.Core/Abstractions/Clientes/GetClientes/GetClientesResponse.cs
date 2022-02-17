namespace CRUDCliente.Core.Abstractions.Clientes.GetClientes
{
    public class GetClientesResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
    }
}
