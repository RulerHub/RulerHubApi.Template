using RulerHub.Application.DTOs.Products;
using RulerHub.Application.Interfaces.Mappers;
using RulerHub.Application.Mappers;
using RulerHub.Domain.Entities.Stores;

namespace RulerHub.Api.Extensions;

public static class MappersExtension
{
    public static IServiceCollection AddMapperExtension(this IServiceCollection services)
    {
        services.AddScoped<IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto>, ProductMapper>();

        return services;
    }
}
