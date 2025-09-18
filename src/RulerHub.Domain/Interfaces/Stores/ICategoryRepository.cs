using RulerHub.Domain.Entities.Abstracts;
using RulerHub.Domain.Entities.Stores;
using RulerHub.Domain.Interfaces.Abstracts;

namespace RulerHub.Domain.Interfaces.Stores;

public interface ICategoryRepository : IRepository<Category>
{
    Task<(IEnumerable<Category> Items, int TotalCount)> GetFilteredAsync(CategoryQueryParams query);
}
