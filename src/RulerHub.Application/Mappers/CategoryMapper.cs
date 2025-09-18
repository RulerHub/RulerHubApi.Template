using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RulerHub.Application.DTOs.Categories;
using RulerHub.Application.Interfaces.Mappers;
using RulerHub.Domain.Entities.Stores;

namespace RulerHub.Application.Mappers;

public class CategoryMapper : IMapper<Category, CategoryDto, CategoryCreateDto, CategoryUpdateDto>
{
    public Category FromCreateDto(CategoryCreateDto dto)
    => new() 
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Description = dto.Description
    };

    public CategoryDto ToDto(Category entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateEntity(Category entity, CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
