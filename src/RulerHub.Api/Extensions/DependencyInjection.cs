using RulerHub.Application.Interfaces.Services;
using RulerHub.Application.Services;
using RulerHub.Domain.Interfaces.Abstracts;
using RulerHub.Domain.Interfaces.Stores;
using RulerHub.Infrastructure.Data.UnitOfWorks;
using RulerHub.Infrastructure.Repositories;

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
