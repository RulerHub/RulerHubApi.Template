using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Mappers;
using RulerHub.Api.Application.Mappers;

namespace RulerHub.Api.Extensions;

public static class MappersExtension
{
    public static IServiceCollection AddMapperExtension(this IServiceCollection services)
    {
        services.AddScoped<IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto>, ProductMapper>();

        return services;
    }
}
