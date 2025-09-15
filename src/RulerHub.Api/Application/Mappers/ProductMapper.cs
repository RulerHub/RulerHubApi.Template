using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Mappers;
using RulerHub.Api.Core.Entities.Stores;

namespace RulerHub.Api.Application.Mappers;

public class ProductMapper : IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto>
{
    public Product FromCreateDto(ProductCreateDto dto)
    => new()
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Price = dto.Price,
        CategoryId = dto.CategoryId
    };

    public ProductDto ToDto(Product entity)
    => new(entity.Id, entity.Name, entity.Price, entity.Category.Name);

    public void UpdateEntity(Product entity, ProductCreateDto dto)
    {
        entity.Name = dto.Name;
        entity.Price = dto.Price;
        entity.CategoryId = dto.CategoryId;
    }
}
