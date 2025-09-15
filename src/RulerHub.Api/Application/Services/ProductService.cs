
using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Mappers;
using RulerHub.Api.Application.Interfaces.Services;
using RulerHub.Api.Core.Entities.Stores;
using RulerHub.Api.Domain.Interfaces;

namespace RulerHub.Api.Application.Services;

public class ProductService(IUnitOfWork unitOfWork, 
    IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto> mapper) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto> _mapper = mapper;

    public async Task<ProductDto> CreateAsync(ProductCreateDto dto)
    {
        var entity = _mapper.FromCreateDto(dto);
        await _unitOfWork.Products.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.Products.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(id);
        return entity is null ? null : _mapper.ToDto(entity);
    }

    public async Task<(IEnumerable<ProductDto> Items, int TotalCount)> GetFilteredAsync(ProductQueryParams query)
    {
        var (items, total) = await _unitOfWork.Products.GetFilteredAsync(query);
        return (items.Select(_mapper.ToDto), total);
    }

    public async Task UpdateAsync(Guid id, ProductCreateDto dto)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(id);
        if (entity is null) return;
        _mapper.UpdateEntity(entity, dto);
        await _unitOfWork.Products.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }
}
