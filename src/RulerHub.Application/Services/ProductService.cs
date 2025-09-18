using RulerHub.Application.DTOs.Products;
using RulerHub.Application.Interfaces.Mappers;
using RulerHub.Application.Interfaces.Services;
using RulerHub.Domain.Entities.Abstracts;
using RulerHub.Domain.Entities.Stores;
using RulerHub.Domain.Interfaces.Abstracts;

namespace RulerHub.Application.Services;

public class ProductService(IUnitOfWork unitOfWork,
    IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto> mapper) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper<Product, ProductDto, ProductCreateDto, ProductCreateDto> _mapper = mapper;

    public async Task<ProductDto> CreateAsync(ProductCreateDto dto)
    {
        var entity = _mapper.FromCreateDto(dto);
        await _unitOfWork.BeginTransactionAsync();
        await _unitOfWork.Products.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
        return _mapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.BeginTransactionAsync();
        await _unitOfWork.Products.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(id);
        return entity is null ? null : _mapper.ToDto(entity);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var items = await _unitOfWork.Products.GetAllAsync();
        return items.Select(_mapper.ToDto);
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
        await _unitOfWork.BeginTransactionAsync();
        await _unitOfWork.Products.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
    }
}
