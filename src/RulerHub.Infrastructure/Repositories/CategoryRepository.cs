using Microsoft.EntityFrameworkCore;

using RulerHub.Domain.Entities.Abstracts;
using RulerHub.Domain.Entities.Stores;
using RulerHub.Domain.Interfaces.Stores;
using RulerHub.Infrastructure.Data;

namespace RulerHub.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddAsync(Category entity)
        => await _context.Categories
            .AddAsync(entity);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null) return;
            _context.Categories
                .Remove(entity);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        => await _context.Categories
            .ToListAsync();

        public async Task<Category?> GetByIdAsync(Guid id)
        => await _context.Categories
            .Include(p => p.Products)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<(IEnumerable<Category> Items, int TotalCount)> GetFilteredAsync(CategoryQueryParams query)
        {
            var q = _context.Categories
                .Include(p => p.Products)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Search))
                q = q.Where(p => p.Name.Contains(query.Search));
            q = query.SortBy?.ToLower() switch
            {
                _ => query.Descending ? q.OrderByDescending(p => p.Name)
                    : q.OrderBy(p => p.Name),
            };

            var total = await q.CountAsync();

            var items = await q
            .ToListAsync();

            return (items, total);
        }

        public async Task UpdateAsync(Category entity)
        => _context.Categories.Update(entity);
    }
}
