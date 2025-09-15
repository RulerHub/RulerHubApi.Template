using RulerHub.Api.Core.Entities.Abstracts;

namespace RulerHub.Api.Core.Entities.Stores;

public class Category : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public IEnumerable<Product> Products { get; set; } = [];
}
