using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Mappers;
using RulerHub.Api.Application.Interfaces.Services;
using RulerHub.Api.Application.Mappers;
using RulerHub.Api.Application.Services;
using RulerHub.Api.Core.Entities.Stores;
using RulerHub.Api.Domain.Interfaces;
using RulerHub.Api.Infrastructure.Repositories;
using RulerHub.Api.Infrastructure.UnitOfWorks;

namespace RulerHub.Api.Extensions;

public static class MappersExtension
{
    public static IServiceCollection AddMapperExtension(this IServiceCollection services)
    {
        services.AddScoped<IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto>, ProductMapper>();

        return services;
    }
}
