using CRUDCliente.Core;
using CRUDCliente.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDCliente.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddData();
            services.AddCore(config);
            return services;
        }
    }
}