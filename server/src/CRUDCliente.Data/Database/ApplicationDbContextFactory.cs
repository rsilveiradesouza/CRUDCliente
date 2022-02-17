using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CRUDCliente.Data.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).FullName);
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Join(Directory.GetParent(Environment.CurrentDirectory).FullName, "CRUDCliente.Api"))
            .AddJsonFile("appsettings.Development.json")
            .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CRUDCliente.Data")).Options;
            var monitoramentoApiContexto = new ApplicationDbContext(options);
            return monitoramentoApiContexto;
        }
    }
}