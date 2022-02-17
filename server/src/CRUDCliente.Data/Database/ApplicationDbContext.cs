using CRUDCliente.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRUDCliente.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
            builder.HasDefaultSchema("CRUDCliente");
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
