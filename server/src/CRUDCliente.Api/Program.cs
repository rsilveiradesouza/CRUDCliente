using CRUDCliente.Data.Database;
using CRUDCliente.IoC;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddMyDependencies(builder.Configuration);
services.AddDbContext<ApplicationDbContext>(options => options
                .UseLoggerFactory(LoggerFactory.Create(
                            builder =>
                            {
                                builder.AddConsole();
                                builder.SetMinimumLevel(LogLevel.Information);
                            })
                )
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true));

services.AddCors(opt => opt.AddPolicy("CorsPolicy", new CorsPolicyBuilder()
               .SetIsOriginAllowed(origin => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               .Build()));

services.AddSwaggerGen(c =>
{
    c.AddServer(new OpenApiServer()
    {
        Url = $"/{builder.Configuration["swagger:IisApplication"]}",
        Description = "API do sistema - CRUDCliente"
    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRUDCliente",
        Version = "v1",
        Description = "API do sistema CRUDCliente"
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.OrderActionsBy(d => d.GroupName);
    c.EnableAnnotations();
    c.CustomSchemaIds(x => x.FullName);
    c.DescribeAllParametersInCamelCase();
}).AddSwaggerGenNewtonsoftSupport();

services.AddResponseCompression(c =>
{
    c.Providers.Add<GzipCompressionProvider>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger().UseSwaggerUI(options =>
{
    options.DocExpansion(DocExpansion.None);
    if (string.IsNullOrWhiteSpace(builder.Configuration["swagger:IisApplication"]))
    {
        options.SwaggerEndpoint($"{builder.Configuration["swagger:path"]}", "CRUDCliente");
    }
    else
    {
        options.SwaggerEndpoint($"/{builder.Configuration["swagger:IisApplication"]}{builder.Configuration["swagger:path"]}", "CRUDCliente");
    }
});
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
