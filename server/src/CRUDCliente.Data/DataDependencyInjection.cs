using Microsoft.Extensions.DependencyInjection;

namespace CRUDCliente.Data
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromCallingAssembly()
                .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}