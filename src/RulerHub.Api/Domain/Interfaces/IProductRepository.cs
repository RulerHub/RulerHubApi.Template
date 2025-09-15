using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Core.Entities.Stores;

namespace RulerHub.Api.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<(IEnumerable<Product> Items, int TotalCount)> GetFilteredAsync(ProductQueryParams query);
}
