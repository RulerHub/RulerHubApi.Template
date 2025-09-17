using Microsoft.EntityFrameworkCore;

using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Domain.Interfaces;
using RulerHub.Api.Infrastructure.Data;

namespace RulerHub.Api.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context
;

    public async Task AddAsync(Product entity)
    => await _context.Products.AddAsync(entity);

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Products.Remove(entity);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    => await _context.Products
        //.Include(p => p.Category)
        .ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id)
    => await _context.Products
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<(IEnumerable<Product> Items, int TotalCount)> GetFilteredAsync(ProductQueryParams query)
    {
        var q = _context.Products
            //.Include(p => p.Category)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(p => p.Name.Contains(query.Search));
        q = query.SortBy?.ToLower() switch
        {
            "price" => query.Descending ? q.OrderByDescending(p => p.Price)
                : q.OrderBy(p => p.Price),
            _ => query.Descending ? q.OrderByDescending(p => p.Name)
                : q.OrderBy(p => p.Name),
        };

        var total = await q.CountAsync();

        var items = await q
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return (q, total);
    }

    public async Task UpdateAsync(Product entity)
    => _context.Products.Update(entity);
}
