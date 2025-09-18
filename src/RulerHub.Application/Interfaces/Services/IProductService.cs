using RulerHub.Application.DTOs.Products;
using RulerHub.Domain.Entities.Abstracts;

namespace RulerHub.Application.Interfaces.Services;

public interface IProductService
{
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<(IEnumerable<ProductDto> Items, int TotalCount)> GetFilteredAsync(ProductQueryParams query);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> CreateAsync(ProductCreateDto dto);
    Task UpdateAsync(Guid id, ProductCreateDto dto);
    Task DeleteAsync(Guid id);
}
