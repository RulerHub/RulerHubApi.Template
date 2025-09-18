using RulerHub.Domain.Entities.Abstracts;
using RulerHub.Domain.Entities.Stores;
using RulerHub.Domain.Interfaces.Abstracts;

namespace RulerHub.Domain.Interfaces.Stores;

public interface IProductRepository : IRepository<Product>
{
    Task<(IEnumerable<Product> Items, int TotalCount)> GetFilteredAsync(ProductQueryParams query);
}
