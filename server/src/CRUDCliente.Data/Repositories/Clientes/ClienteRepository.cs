using CRUDCliente.Contracts.Repositories.Clientes;
using CRUDCliente.Data.Database;
using CRUDCliente.Domain.Clientes;

namespace CRUDCliente.Data.Repositories.Clientes
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}