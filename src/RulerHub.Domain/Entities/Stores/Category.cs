using RulerHub.Domain.Entities.Abstracts;

namespace RulerHub.Domain.Entities.Stores;

public class Category : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public IEnumerable<Product>? Products { get; set; } = [];
}
