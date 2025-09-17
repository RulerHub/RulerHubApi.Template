using RulerHub.Api.Application.Interfaces.Services;
using RulerHub.Api.Application.Services;
using RulerHub.Api.Domain.Interfaces;
using RulerHub.Api.Infrastructure.Repositories;
using RulerHub.Api.Infrastructure.UnitOfWorks;

namespace RulerHub.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
    {
        // ToDo: Add services here
        services.AddControllers();
        services.AddMapperExtension();
        services.AddSwaggerExtension(configuration);
        services.AddDbContextExtension(configuration);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
