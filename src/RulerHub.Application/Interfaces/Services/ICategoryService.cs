using RulerHub.Application.DTOs.Categories;
using RulerHub.Domain.Entities.Abstracts;

namespace RulerHub.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<CategoryDto?> GetByIdAsync(Guid id);
    Task<(IEnumerable<CategoryDto> Items, int TotalCount)> GetFilteredAsync(CategoryQueryParams query);
    Task<CategoryDto> CreateAsync(CategoryCreateDto dto);
    Task UpdateAsync(Guid id, CategoryUpdateDto dto);
    Task DeleteAsync(Guid id);
}
