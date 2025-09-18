using RulerHub.Application.DTOs.Products;
using RulerHub.Application.Interfaces.Mappers;
using RulerHub.Domain.Entities.Stores;
using RulerHub.Infrastructure.Data;

namespace RulerHub.Application.Mappers;

public class ProductMapper(ApplicationDbContext context) : IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto>
{
    private readonly ApplicationDbContext _context = context;
    public Product FromCreateDto(ProductCreateDto dto)
    => new()
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Price = dto.Price
    };

    public ProductDto ToDto(Product entity)
    {
        var createdAt = _context
            .Entry(entity).Property<DateTime>("CreatedAt").CurrentValue;
        var updatedAt = _context
            .Entry(entity).Property<DateTime?>("UpdatedAt").CurrentValue;
        return new(entity.Id, entity.Name, entity.Price, createdAt, updatedAt);
    }

    public void UpdateEntity(Product entity, ProductCreateDto dto)
    {
        entity.Name = dto.Name;
        entity.Price = dto.Price;
    }
}
